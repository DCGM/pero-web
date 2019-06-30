import os
import uuid
import bmod.test_transcriptions as test_transcriptions

from bmod.transcription import Transcription
from bmod.result import Result, Status
from bmod.eval_data import EvalData


def save_file(req, input_name, path):
    if not os.path.exists(path):
        os.makedirs(path)

    file_path = None
    name = uuid.uuid4().hex + ".txt"

    if input_name in req.files:
        file = req.files[input_name]
        file_path = os.path.join(path, name)
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

