{% extends 'template.html.cs' %}

{% block header %}
    Pomozte nám při určování vizuální kvality dokumentu
{% endblock %}

{% block perex %}
    <p>
		Jednou z oblastí, kterou se zabýváme, je určování vizuální kvality dokumentu.
		Toto je důležité například pro následné upravování dokumentů tak, aby rozpoznání textu bylo co nejlepší.
		Porovnávat dva dokumenty z tohoto pohledu pomocí algoritmů je velmi obtížné, někdy i nemožné.
		Je tudíž potřeba ručně zjistit, které dokumenty vypadají lépe.
    </p>
{% endblock %}

{% block content %}
    <p>
    	Pro zjednodušení práce při porovnávání dokumentů jsme vytvořili <a href="http://pchradis2.fit.vutbr.cz:8001/comparing/1">anotační server</a>.
		Zobrazí se vám zde dva výřezy z různách dokumentů a jediným úkolem je označit ten lépe vypadající pomocí tlačítka nad obrázkem.
		Byli bychom velice rádi, pokud byste nám s porovnáváním pomohli a přispěli tak ke zlepšení rozpoznávání textu.
    </p>
{% endblock %}
