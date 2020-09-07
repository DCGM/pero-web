{% extends 'template.html.cs' %}

{% block header %}
    Aktualizace pero-ocr
{% endblock %}

{% block perex %}
    <p>
		V průběhu srpna jsme aktualizovali náš pythonový balíček pero-ocr na verzi 0.3.
		Tento balíček vychází z našich kódů dostupných v GitHubovém repozitáři <a class="dotted-link" href="https://github.com/DCGM/pero-ocr">pero-ocr</a>.
    </p>
{% endblock %}

{% block content %}
	<p>
		V nejnovější verzi jsme především přidali optimalizované dekódování s jazykovým modelem, opravili chybu při výstupu ve formátu ALTO XML a upravili a vylepšili analýzu rozložení stránky a detekci řádků.
	</p>
{% endblock %}