from enum import Enum

class Language(Enum):
    english = 0
    czech = 1

    @staticmethod
    def from_string(value):
        if value.lower() in ("cs", "cz"):
            return Language.czech
        else:
            return Language.english

    @staticmethod
    def to_string(language):
        if language == Language.czech:
            return "cs"
        else:
            return "en"

class Message(Enum):
    server_config_failure = 0
    save_files_failure = 1
    files_saved_successfully = 2
    allowed_extensions = 3


texts = {
    Message.server_config_failure: {
        Language.english: "There is a problem with server configuration.",
        Language.czech: "Nastal problém s konfigurací serveru."
    },
    Message.save_files_failure: {
        Language.english: "There was a problem saving your file(s).",
        Language.czech: "Při ukládání souborů došlo k chybě."
    },
    Message.files_saved_successfully: {
        Language.english: "File(s) successfully saved. Thank you for participating.",
        Language.czech: "Soubory úspěšně uloženy. Děkujeme za přispění."
    },
    Message.allowed_extensions: {
        Language.english: "Allowed extensions",
        Language.czech: "Povolené přípony"
    }

}

