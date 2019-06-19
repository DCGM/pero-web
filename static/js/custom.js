window.onload = function () {
    hwr_upload_file_input = document.getElementById("hwr_upload_file_input");
    if (hwr_upload_file_input != null) {
        hwr_upload_file_input.addEventListener("change", updateNumberOfFiles);
    }

    bmod_upload_file_input = document.getElementById("bmod_upload_file_input")
    if (bmod_upload_file_input != null) {
        bmod_upload_file_input.addEventListener("change", updateInputText);
    }
}

function updateNumberOfFiles() {
    console.log("UPDATE");
    var uploadInput = document.getElementById("hwr_upload_file_input");
    var uploadLabel = document.getElementById("hwr_upload_label");

    var selectedFiles = uploadInput.files;

    console.log(selectedFiles);

    if (selectedFiles.length === 0) {
        uploadLabel.innerText = "Choose file";
    } else {
        uploadLabel.innerText = "Selected files: " + selectedFiles.length;
    }
}

function getRandomHandwrittenPage() {
    window.location = "/get_handwritten_page?random=" + Math.floor(Math.random() * Number.MAX_SAFE_INTEGER);
}

function uploadHandwrittenPages() {
    var uploadInput = document.getElementById("hwr_upload_file_input");

    console.log(uploadInput.value)

    if (uploadInput.value == "") {
        document.getElementById("error_block").style.display = "block";
        document.getElementById("hwr_upload_form_no_file_message").style.display = "block";
    } else {
        document.getElementById("handwritten_dataset_form").submit();
    }
}


function updateInputText() {

    var uploadInput = document.getElementById("bmod_upload_file_input");
    var uploadLabel = document.getElementById("bmod_upload_label");

    var selectedFiles = uploadInput.files;

    console.log(selectedFiles);

    if (selectedFiles.length === 0) {
        uploadLabel.innerText = "Choose file";
    } else {
        uploadLabel.innerText = getFileName(selectedFiles[0].name);
    }
}

function getFileName(name) {
    threshold = 20
    last_chars = 4
    substitution = " ... "

    if (name.length > threshold) {
        suffix = name.substring(name.length - last_chars)
        name = name.substring(0, threshold - substitution.length - last_chars) + substitution + suffix
    }

    console.log(name)
    console.log(name.length)

    return name
}

function uploadBMODTranscriptionFile() {
    var uploadInput = document.getElementById("bmod_upload_file_input");

    if (uploadInput.value == "") {
        document.getElementById("error_block").style.display = "block";
        document.getElementById("bmod_upload_form_no_file_message").style.display = "block";
    } else {
        document.getElementById("bmod_upload_form").submit();
    }
}
