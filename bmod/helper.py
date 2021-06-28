import datetime
import os
import uuid
from typing import List
import bmod.test_transcriptions as test_transcriptions

from bmod.transcription import Transcription
from bmod.result import Result, Status
from bmod.eval_data import EvalData
from bmod.eval_result import  EvaluationResult


def create_default_result_file(path):
    with open(path, "w") as f:
        f.write("Baseline LSTM\tCNN-LSTM-CTC\t30.06.2019\t0.33\t1.93\t5.65\t22.39\t32.28\t72.63\t3.15\t10.71\n")
        f.write("Baseline Conv\tCNN-CTC\t30.06.2019\t0.50\t2.79\t7.82\t28.50\t39.76\t80.69\t4.19\t13.39\n")


def parse_results(path):
    results = []

    if not os.path.isfile(path):
        create_default_result_file(path)

    with open(path, "r") as f:
        for line in f:
            line = line.strip()
            if len(line) > 0:
                results.append(parse_eval_result(line))

    return results


def parse_eval_result(line):
    try:
        name, description, date, \
            cer_easy, wer_easy, \
            cer_medium, wer_medium, \
            cer_hard, wer_hard, \
            cer_overall, wer_overall = line.split("\t")
    except:
        print(line)
        raise

    return EvaluationResult(name, description, date, cer_easy, wer_easy, cer_medium, wer_medium, cer_hard, wer_hard, cer_overall, wer_overall)


def save_file(req, name, description, input_name, destination_directory, translation_file_path):
    if not os.path.exists(destination_directory):
        os.makedirs(destination_directory)

    file_path = None
    unique_name = uuid.uuid4().hex + ".txt"

    with open(translation_file_path, "a") as f:
        f.write("{filename}\t{name}\t{description}\n".format(filename=unique_name, name=name, description=description))

    if input_name in req.files:
        file = req.files[input_name]
        file_path = os.path.join(destination_directory, unique_name)
        file.save(file_path)

    return file_path


def evaluate(transcription_path, ground_truth_easy, ground_truth_medium, ground_truth_hard):
    try:
        # result_easy = test_transcriptions.test_files(transcription_path, ground_truth_easy)
        result_easy = Result(Status.SUCCESS, (0, 0), "")
        result_medium = test_transcriptions.test_files(transcription_path, ground_truth_medium)
        result_hard = test_transcriptions.test_files(transcription_path, ground_truth_hard)
        
        cer_easy, wer_easy = result_easy.data
        cer_medium, wer_medium = result_medium.data
        cer_hard, wer_hard = result_hard.data

        overall_status = Status.FAILURE
        message = ""

        if result_easy.status == Status.FAILURE:
            message = result_easy.message

        if result_medium.status == Status.FAILURE:
            message = result_medium.message

        if result_hard.status == Status.FAILURE:
            message = result_hard.message

        if result_easy.status == Status.SUCCESS and result_medium.status == Status.SUCCESS and result_hard.status == Status.SUCCESS:
            overall_status = Status.SUCCESS
        
        result = Result(overall_status, EvalData(transcription_path, cer_easy, wer_easy, cer_medium, wer_medium, cer_hard, wer_hard), message)
    except:
        result = Result(Status.FAILURE, "Something unexpectedly failed during evaluation.")

    return result


def write_results_file(name, description, path):
    date = datetime.datetime.utcnow().strftime("%d.%m.%Y")
    with open(path, "a") as f:
        f.write("{name}\t{description}\t{date}\tN/A\tN/A\tN/A\tN/A\tN/A\tN/A\tN/A\tN/A\n".format(name=name, description=description, date=date))


def check_name(evaluation_results: List[EvaluationResult], name, description):
    for evaluation_result in evaluation_results:
        if evaluation_result.name == name:
            return False

    return True

def highlight_best_result(results):
    if results is None or len(results) == 0:
        return

    best_result_index = None

    for index, result in enumerate(results):
        try:
            cer_overall = float(result.cer_overall)
        except ValueError:
            continue

        if best_result_index is None or cer_overall < float(results[best_result_index].cer_overall):
            best_result_index = index

    if best_result_index is not None:
        update_results_appearance(results, best_result_index, "<b>", "</b>")

    if results[0].name == "Baseline LSTM" and results[0].description == "CNN-LSTM-CTC":
        update_results_appearance(results, 0, "<i>", "</i>")

    if results[1].name == "Baseline Conv" and results[1].description == "CNN-CTC":
        update_results_appearance(results, 1, "<i>", "</i>")


def update_results_appearance(results, index, start_tag, end_tag):
    results[index].name = f'{start_tag}{results[index].name}{end_tag}'
    results[index].description = f'{start_tag}{results[index].description}{end_tag}'
    results[index].date = f'{start_tag}{results[index].date}{end_tag}'
    results[index].cer_easy = f'{start_tag}{results[index].cer_easy}{end_tag}'
    results[index].wer_easy = f'{start_tag}{results[index].wer_easy}{end_tag}'
    results[index].cer_medium = f'{start_tag}{results[index].cer_medium}{end_tag}'
    results[index].wer_medium = f'{start_tag}{results[index].wer_medium}{end_tag}'
    results[index].cer_hard = f'{start_tag}{results[index].cer_hard}{end_tag}'
    results[index].wer_hard = f'{start_tag}{results[index].wer_hard}{end_tag}'
    results[index].cer_overall = f'{start_tag}{results[index].cer_overall}{end_tag}'
    results[index].wer_overall = f'{start_tag}{results[index].wer_overall}{end_tag}'

