import os
import sys
import argparse
from bmod.transcription import Transcription
from bmod.result import Status, Result
from bmod.eval_data import EvalData


def parse_arguments():
    parser = argparse.ArgumentParser()
    parser.add_argument('-t', '--transcriptions', help='Path to transcriptions file.', required=True)
    parser.add_argument('-g', '--ground-truth', help='Path to ground truth file.', required=True)
    args = parser.parse_args()
    return args


def load_transcriptions(path):
    transcriptions = {}
    with open(path, "r") as f:
        for line in f:
            line = line.strip()
            if len(line) > 0:
                line_parts = line.split(maxsplit=1)
                line_parts_count = len(line_parts)
                if line_parts_count > 0:
                    file = line_parts[0]
                    transcription = ""

                    if line_parts_count == 2:
                        transcription = line_parts[1]

                    transcriptions[file] = transcription

    return Result(Status.SUCCESS, transcriptions)


def test(transcriptions, ground_truths_easy, ground_truths_medium, ground_truths_hard):
    lines_easy_result = process_lines(transcriptions, ground_truths_easy)
    if lines_easy_result.status == Status.FAILURE:
        return lines_easy_result

    lines_easy = lines_easy_result.data
    if len(lines_easy) == 0:
        return Result(Status.FAILURE, None, "There are no lines to calculate CER and WER.")

    lines_medium_result = process_lines(transcriptions, ground_truths_medium)
    if lines_medium_result.status == Status.FAILURE:
        return lines_medium_result

    lines_medium = lines_medium_result.data
    if len(lines_medium) == 0:
        return Result(Status.FAILURE, None, "There are no lines to calculate CER and WER.")
    
    lines_hard_result = process_lines(transcriptions, ground_truths_hard)
    if lines_hard_result.status == Status.FAILURE:
        return lines_hard_result

    lines_hard = lines_hard_result.data
    if len(lines_hard) == 0:
        return Result(Status.FAILURE, None, "There are no lines to calculate CER and WER.")

    char_errors_easy = sum([line.char_distance() for line in lines_easy])
    char_errors_medium = sum([line.char_distance() for line in lines_medium])
    char_errors_hard = sum([line.char_distance() for line in lines_hard])

    char_length_easy = sum([len(line.ground_truth) for line in lines_easy])
    char_length_medium = sum([len(line.ground_truth) for line in lines_medium])
    char_length_hard = sum([len(line.ground_truth) for line in lines_hard])

    word_errors_easy = sum([line.word_distance() for line in lines_easy])
    word_errors_medium = sum([line.word_distance() for line in lines_medium])
    word_errors_hard = sum([line.word_distance() for line in lines_hard])
    
    word_length_easy = sum([len(line.ground_truth.split()) for line in lines_easy])
    word_length_medium = sum([len(line.ground_truth.split()) for line in lines_medium])
    word_length_hard = sum([len(line.ground_truth.split()) for line in lines_hard])

    cer_easy = float(char_errors_easy) / char_length_easy
    wer_easy = float(word_errors_easy) / word_length_easy

    cer_medium = float(char_errors_medium) / char_length_medium
    wer_medium = float(word_errors_medium) / word_length_medium

    cer_hard = float(char_errors_hard) / char_length_hard
    wer_hard = float(word_errors_hard) / word_length_hard

    cer_overall = float(sum([char_errors_easy, char_errors_medium, char_errors_hard])) / sum([char_length_easy, char_length_medium, char_length_hard])
    wer_overall = float(sum([word_errors_easy, word_errors_medium, word_errors_hard])) / sum([word_length_easy, word_length_medium, word_length_hard])

    return Result(Status.SUCCESS, EvalData(None, cer_easy, wer_easy, cer_medium, wer_medium, cer_hard, wer_hard, cer_overall, wer_overall))


def process_lines(transcriptions, ground_truths):
    missing = []
    lines = []

    for index, image_id in enumerate(ground_truths):
        ground_truth = ground_truths[image_id]
        transcription = ""

        if image_id in transcriptions:
            transcription = transcriptions[image_id]
        else:
            missing.append(image_id)

        line = Transcription(image_id, ground_truth, transcription)

        lines.append(line)

    message = "Missing transcriptions for lines: '{lines}'.".format(lines="', '".join(missing))

    return Result(Status.SUCCESS, lines, message=message)


def test_files(transcriptions_path: str, ground_truths_easy_path: str, ground_truths_medium_path: str, ground_truths_hard_path: str) -> Result:
    '''
    Args:
        transcriptions_path (str): Path to transcription file.
        ground_truths_path (str): Path to ground-truth file.

    Returns:
        Result: Result object with success status and optionally with data or with detailed information about failure.
    '''
    transcriptions_result = load_transcriptions(transcriptions_path)
    if transcriptions_result.status == Status.FAILURE:
        return transcriptions_result

    ground_truths_easy_result = load_transcriptions(ground_truths_easy_path)
    if ground_truths_easy_result.status == Status.FAILURE:
        return ground_truths_easy_result
    
    ground_truths_medium_result = load_transcriptions(ground_truths_medium_path)
    if ground_truths_medium_result.status == Status.FAILURE:
        return ground_truths_medium_result
    
    ground_truths_hard_result = load_transcriptions(ground_truths_hard_path)
    if ground_truths_hard_result.status == Status.FAILURE:
        return ground_truths_hard_result

    result = test(transcriptions_result.data, ground_truths_easy_result.data, ground_truths_medium_result.data, ground_truths_hard_result.data)

    return result


def main():
    args = parse_arguments()

    result = test_files(args.transcriptions, args.ground_truth)
    if result.status == Status.SUCCESS:
        cer, wer = result.data
        print("CER: {cer}\nWER: {wer}".format(cer=cer, wer=wer))
    else:
        print(result)

    return 0


if __name__ == "__main__":
    sys.exit(main())
