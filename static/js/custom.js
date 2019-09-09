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
    var uploadInput = document.getElementById("hwr_upload_file_input");
    var uploadLabel = document.getElementById("hwr_upload_label");

    var selectedFiles = uploadInput.files;

    var language = getLanguage();

    if (selectedFiles.length === 0) {
        if (language == "cs") {
            uploadLabel.innerText = "Vyberte soubor";
        } else {
            uploadLabel.innerText = "Choose file";
        }
    } else {
        if (language == "cs") {
            uploadLabel.innerText = "Vybráno souborů: " + selectedFiles.length;
        } else {
            uploadLabel.innerText = "Selected files: " + selectedFiles.length;
        }
    }
}

function getRandomHandwrittenPage() {
    gtag('event', 'HWR', {'event_category': 'Download pages'});
    console.log("GET");
    window.location = "/get_handwritten_page?a="+Math.random();
}

function uploadHandwrittenPages() {
    var uploadInput = document.getElementById("hwr_upload_file_input");

    if (uploadInput.value == "") {
        document.getElementById("error_block").style.display = "block";
        document.getElementById("hwr_upload_form_no_file_message").style.display = "block";
    } else {
        gtag('event', 'HWR', {'event_category': 'Upload image'});
        document.getElementById("handwritten_dataset_form").submit();
    }
}


function updateInputText() {
    var uploadInput = document.getElementById("bmod_upload_file_input");
    var uploadLabel = document.getElementById("bmod_upload_label");

    var selectedFiles = uploadInput.files;

    if (selectedFiles.length === 0) {
        var language = getLanguage();

        if (language == "cs") {
            uploadLabel.innerText = "Vyberte soubor";
        } else {
            uploadLabel.innerText = "Choose file";
        }
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

    return name
}

function uploadBMODTranscriptionFile() {
    var uploadNameInput = document.getElementById("bmod_upload_name")
    var uploadFileInput = document.getElementById("bmod_upload_file_input");

    if (uploadNameInput.value == "") {
        document.getElementById("bmod_upload_form_no_file_message").style.display = "none";
        document.getElementById("error_block").style.display = "block";
        document.getElementById("bmod_upload_form_empty_name_message").style.display = "block";
    }
    else if (uploadFileInput.value == "") {
        document.getElementById("bmod_upload_form_empty_name_message").style.display = "none";
        document.getElementById("error_block").style.display = "block";
        document.getElementById("bmod_upload_form_no_file_message").style.display = "block";
    } else {
        document.getElementById("bmod_upload_form").submit();
    }
}

function getLanguage() {
    language = getCookie("pero_language");

    if (language == "") {
        language = "en"
    }

    return language
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for(var i = 0; i < ca.length; i++) {
        var c = ca[i];

        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }

        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }

    return "";
}

function setLanguage(language) {
    setCookie("pero_language", language, 30);
    location.reload();
}

function setCookie(cname, cvalue, exdays) {
  var d = new Date();
  d.setTime(d.getTime() + (exdays*24*60*60*1000));
  var expires = "expires="+ d.toUTCString();
  document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

$(document).ready(function(){
    //FANCYBOX
    //https://github.com/fancyapps/fancyBox
    $(".fancybox").fancybox({
        helpers : {
            title : {
                type : 'over'
            }
        },
        openEffect: "none",
        closeEffect: "none",
    });
});
