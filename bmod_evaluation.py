import sys
import time
import argparse
import bmod.test_transcriptions as test_transcriptions
import config_helper
from watchdog.observers import Observer
from watchdog.events import FileSystemEventHandler


configuration = None


class MyEventHandler(FileSystemEventHandler):
    def __init__(self, observer):
        self.observer = observer

    def on_created(self, event):
        if event.event_type == "created" and not event.src_path.endswith(("results.txt", "translation.txt")):
            print("Evaluating", event.src_path)
            results = evaluate(event.src_path)
            write_results(event.src_path, results)


def parse_arguments():
    parser = argparse.ArgumentParser()
    parser.add_argument('-c', '--config', help='Path to config file.', required=True)
    args = parser.parse_args()
    return args


def load_translations(path):
    translation = {}

    with open(path, "r") as f:
        for line in f:
            line = line.strip()
            if len(line) > 0:
                id, name, description = line.split("\t")
                translation[id] = (name, description)

    return translation


def evaluate(path):
    return test_transcriptions.test_files(
        path,
        configuration["brno_mobile_ocr_dataset"]["ground_truth_easy"],
        configuration["brno_mobile_ocr_dataset"]["ground_truth_medium"],
        configuration["brno_mobile_ocr_dataset"]["ground_truth_hard"])


def write_results(file, results):
    file_id = file.split("/")[-1]
    translation = load_translations(configuration["brno_mobile_ocr_dataset"]["translation_file"])

    try:
        name, description = translation[file_id]
    except:
        print("Could not found translation for file with id:", file_id)
        return

    data = load_result_data(configuration["brno_mobile_ocr_dataset"]["result_data"])
    data = update(data, name, description, results)
    write_data(data, configuration["brno_mobile_ocr_dataset"]["result_data"])


def update(data, name, description, results):
    new_data = []

    for line in data:
        if line.startswith("{name}\t{description}".format(name=name, description=description)):
            _, _, date, _ = line.split("\t", maxsplit=3)
            
            new_data.append("{name}\t{description}\t{date}\t{cer_easy}\t{wer_easy}\t{cer_medium}\t{wer_medium}\t{cer_hard}\t{wer_hard}\t{cer_overall}\t{wer_overall}".format(
                name=name,
                description=description,
                date=date,
                cer_easy=results.data.cer_easy,
                wer_easy=results.data.wer_easy,
                cer_medium=results.data.cer_medium,
                wer_medium=results.data.wer_medium,
                cer_hard=results.data.cer_hard,
                wer_hard=results.data.wer_hard,
                cer_overall=results.data.cer_overall,
                wer_overall=results.data.wer_overall,
            ))
        else:
            new_data.append(line)

    return new_data


def load_result_data(path):
    data = []

    with open(path, "r") as f:
        for line in f:
            line = line.strip()
            if len(line) > 0:
                data.append(line)

    return data


def write_data(data, path):
    with open(path, "w") as f:
        for line in data:
            f.write(line + "\n")


def main():
    args = parse_arguments()

    global configuration
    configuration = config_helper.parse_configuration(args.config)

    path = configuration["brno_mobile_ocr_dataset"]["upload_path"]
    observer = Observer()
    event_handler = MyEventHandler(observer)
    observer.schedule(event_handler, path, recursive=True)
    observer.start()

    try:
        while True:
            time.sleep(1)
    except KeyboardInterrupt:
        observer.stop()

    observer.join()
    return 0


if __name__ == "__main__":
    sys.exit(main())
