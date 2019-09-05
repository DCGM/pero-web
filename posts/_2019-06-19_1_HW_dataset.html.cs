{% extends 'template.html.cs' %}

{% block header %}
    Pomozte nám vylepšit přepis ručně psaného písma
{% endblock %}

{% block perex %}
    <p>Systems for automatic handwritten text transcription need training examples from many writers. 
    You have a chance to help us collect such examples and improve transcriptions of historic documents.
    </p>
{% endblock %}

{% block content %}
    <p>
    <a href="https://pero.fit.vutbr.cz/handwritten_dataset">You can download template pages HERE from our web.</a>
    We would appreciate if you could print the pages, write the contained text in your own hand and send us the filled pages by mail 
    or scan them and upload the resulting images using our web. 
    </p>
{% endblock %}
