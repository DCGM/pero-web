{% extends 'template.html.cs' %}

{% block header %}
  Datové sady
{% endblock %}

{% block content %}
<p>V rámci projektu PERO vzniká několik datových sad, přičemž některé jsou již zveřejněny. Níže naleznete odkazy na zveřejněné datasety.</p>

<h2><a href="/handwriting_adaptation_dataset">Handwriting Adaptation Dataset</a></h2>
<p>Handwriting Adaptation Dataset (HAD).</p>
<p></p>

<h2><a href="/handwritten_dataset">Ručně psaný dataset</a></h2>
<p>Prosíme, pomozte nám se sbíráním ručně psaných textů, abychom mohli vylepšit nástroje pro automatické přepisování historických dokumentů. <a href="/handwritten_dataset">Více</a></p>
<p></p>

<h2><a href="/brno_mobile_ocr_dataset">Brno Mobile OCR Dataset</a></h2>
<p>Datová sada Brno Mobile OCR Dataset je primárně zaměřená na vývoj metod pro rozpoznávání textu v obrázcích s nízkou kvalitou. Datová sada obsahuje původní vyfotografované stránky textu s anotacemi a také jednotlivé vyříznuté řádky. Obrázky obsahují různé úrovně šumu, rozmazání a podobně. <a href="/brno_mobile_ocr_dataset">Více</a></p>

<h2><a href="/hdc_dataset">Klasifikace historických dokumentů</a></h2>
<p>Zveřejňujeme rozdělení datových sad, které jsme použili při tvorbě systému pro klasifikaci historických dokumentů v rámci soutěže na ICDAR 2021 (<a href="https://lme.tf.fau.de/competitions/icdar-2021-competition-on-historical-document-classification/">ICDAR 2021 Competition on Historical Document Classification</a>). <a href="/hdc_dataset">Více</a></p>
{% endblock %}
