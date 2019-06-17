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


def evaluate(transcription_path, ground_truth_path):
    try:
        result = test_transcriptions.test_files(transcription_path, ground_truth_path)
        cer, wer = result.data
        result = Result(result.status, EvalData(transcription_path, cer, wer), result.message)
    except:
        result = Result(Status.FAILURE, "Something unexpectedly failed during evaluation.")

    return result

