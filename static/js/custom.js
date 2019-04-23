function getRandomHandwrittenPage() {
    console.log("Ahoj");
    window.location = "/get_handwritten_page?random=" + Math.floor(Math.random() * Number.MAX_SAFE_INTEGER);
}

function uploadHandwrittenPages() {
    var form = document.getElementById("handwritten_dataset_form");
    console.log(form)
    form.submit();
}
