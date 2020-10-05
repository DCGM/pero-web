{% extends 'template.html.cs' %}

{% block header %}
    Vojenský deník
{% endblock %}

{% block perex %}
    <p>
		Jednou z organizací, které využívají služeb našeho softwaru pro automatický přepis ručně psaného písma (PERO-OCR), je <a style="dotted-link" href="http://www.vhu.cz/">Vojenský Historický Ústav Praha (VHÚ)</a>.
		Výsledkem této spolupráce je digitalizovaný <a style="dotted-link" href="http://www.digitalniknihovna.cz/dsmo/uuid/uuid:32f6f706-a323-11ea-95c0-001b63bd97ba">vojenský deník</a>, který již byl importován do Digitální studovny Ministerstva Obrany České republiky.
    </p>
{% endblock %}

{% block content %}
	<p>
		"Muj Deňik", jak se tento dokument nazývá, pochází z období první světové války.
		Deník byl zpracován pomocí nástrojů vyvinutých v rámci projektu PERO a po importování do Digitální studovny je možné vyhledávat v jeho obsahu, případně si obsah jednotlivých stran deníku stáhnout.
	</p>

	<img class="img-fluid" src="/static/img/2020-08-25_3_military_diary_image_0.jpg" alt="Ukázka zpracovaného vojenského deníku."/>
{% endblock %}