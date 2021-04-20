{% extends 'template.html.cs' %}

{% block header %}
  GitHub
{% endblock %}

{% block content %}

<p>Během práce na projektu PERO jsme na GitHubu vytvořili několik repozitářů:</p>

<ul>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero-ocr">PERO OCR</a> - automatické zpracování dokumentů</li>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero_ocr_web">PERO OCR Web</a> - server pro automatické zpracování dokumentů</li>
</ul>

<ul>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero-enhance">PERO Enhance</a> - vylepšení kvality naskenovaných dokumentů</li>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero-quality">PERO Quality</a> - určování kvality naskenovaných dokumentů</li>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero-web">PERO Web</a> - projektový web</li>
	<li><a class="dotted-link" href="https://github.com/DCGM/pero_quality_web">PERO Quality Web</a> - server pro vyhodnocení kvality naskenovaných dokumentů</li>
</ul>

{% endblock %}
