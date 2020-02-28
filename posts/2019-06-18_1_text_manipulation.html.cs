{% extends 'template.html.cs' %}

{% block header %}
    Jak falšovat historické dokumenty?
{% endblock %}

{% block perex %}
    <p>
        Během naší práce na zlepšování kvality obrázků obsahujících text jsme zjistili, že pomocí naší metody je možné snadno změnit jeho obsah.
        Chtěli jste někdy změnit historii? Nyní můžete.
    </p>
{% endblock %}

{% block content %}
    <img class="img-fluid" src="/static/img/2019-06-18_1_text_manipulation_image_0.jpg" alt="Resulting automatic transcriptions on IMPACT dataset."/>
    <img class="img-fluid" src="/static/img/2019-06-18_1_text_manipulation_image_2.jpg" alt="Resulting automatic transcriptions on IMPACT dataset."/>
    <p>
        Naše metoda je založena na Generative Adversarial Network (GAN), jejímž vstupem je poškozený obraz a textový řetězec.
        Textový řetězec je běžně vytvářen našimi modely pro rozpoznávání textu a jazykovými modely, ale lze jej i ručně opravit.
        Normálně by se tento přístup použil k opravě stěží čitelných částí skenovaných dokumentů, ale je možné také úplně změnit text, který ve výsledném obraze bude.
        Doufáme, že tento nástroj bude při uvolnění použit odpovědně.
    </p>
{% endblock %}