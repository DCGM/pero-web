from bmod.result import ImmutableObject


class EvalData(ImmutableObject):
    def __init__(self, id, cer_easy, wer_easy, cer_medium, wer_medium, cer_hard, wer_hard):
        self.id = id
        self.cer_easy = cer_easy
        self.wer_easy = wer_easy
        self.cer_medium = cer_medium
        self.wer_medium = wer_medium
        self.cer_hard = cer_hard
        self.wer_hard = wer_hard

        self.lock()
