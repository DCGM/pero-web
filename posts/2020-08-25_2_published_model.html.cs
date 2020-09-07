{% extends 'template.html.cs' %}

{% block header %}
    Zveřejněné modely
{% endblock %}

{% block perex %}
    <p>
		V našem githubovém repozitáři <a class="dotted-link" href="https://github.com/DCGM/pero-ocr">pero-ocr</a> jsme zveřejnili <a class="dotted-link" href="https://github.com/DCGM/pero-ocr#available-models">dva modely</a> pro veřejné použití.
		Prvním je model, který je určen pro analýzu obecného rozložení tištěných i ručně psaných stránek.
		Druhý model je určený pro rozpoznávání evropského tištěného textu, specializovaný na české noviny.
    </p>
{% endblock %}

{% block content %}
	<p>
		Oba modely i konfigurační soubor jsou kompatibilní s "develop" větví na GitHubu <a class="dotted-link" href="https://github.com/DCGM/pero-ocr">pero-ocr</a>.
	</p>
{% endblock %}