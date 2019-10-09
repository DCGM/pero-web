{% extends 'template.html.cs' %}

{% block header %}
    Best Poster Award na ICDAR 2019
{% endblock %}

{% block perex %}
    <p>
		Na konci září se v australském Sydney uskutečnil 15. ročník <a href="https://www.icdar2019.org">mezinárodní konference o analýze a rozpoznávání dokumentů</a> (<a href="https://www.icdar2019.org">International Conference on Document Analysis and Recognition</a>, zkráceně <a href="https://www.icdar2019.org">ICDAR</a>).
		Této konference jsme se zúčastnili s článkem popisujícím tvorbu <a href="/brno_mobile_ocr_dataset">datasetu B-MOD</a>, který zde byl prezentován pomocí plakátu.
		Za tento plakát jsme obdrželi ocenění pro nejlepší plakát (Best Poster Award).
    </p>
{% endblock %}

{% block content %}
	<img class="img-fluid" src="/static/img/bmod_award.png" alt="B-MOD ocenění za nejlepší plakát">
	<p />
	<img class="img-fluid border border-secondary" src="/static/img/bmod_poster.png" alt="B-MOD plakát">
{% endblock %}