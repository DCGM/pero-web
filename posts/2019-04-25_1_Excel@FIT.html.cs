{% extends 'template.html.cs' %}

{% block header %}
    Aktivní učení pro OCR na studentské konferenci Excel@FIT
{% endblock %}

{% block perex %}
    <p>Jan Kohút publikoval <a href="http://excel.fit.vutbr.cz/submissions/2019/048/48.pdf">výzkumný článek</a> o aktivním učení pro historické OCR a přednesl ústní prezentaci na studentské konferenci <a href="http://excel.fit.vutbr.cz/2019/vysledky/">Excel@FIT 2019</a>.</p>
{% endblock %}

{% block content %}
    <img class="img-fluid" src="/static/img/2019-04-25_Excel.jpg" alt="Resulting automatic transcriptions on IMPACT dataset."/>
    <p>
		Cílem příspěvku bylo vyladění neuronových sítí, které kombinují konvoluční a rekurentní vrstvy, aby poskytovaly vysoce kvalitní automatické přepisy pro řádky historických textů.
        Tyto sítě se pak používají k prozkoumání toho, jak je lze přizpůsobit novým dokumentům při minimalizaci potřeby ručních přepisů.
    </p>
    <p>
        Jan Kohút připravil rozsáhlý dataset historických dokumentů shromážděných a přepsaných v rámci projektu <a href="https://www.digitisation.eu/tools-resources/image-and-ground-truth-resources/">IMPACT</a>.
        Extrahoval řádky pomocí našeho nástroje pro detekci řádků textu a automaticky je zarovnal s textovými přepisy.
        Výsledný dataset obsahuje 1,2 milionu řádků textu s přepisy a zahrnuje devět evropských jazyků a deset písem a abeced.
    </p>
    <p>
        Na tomto náročném datovém souboru jsme dosáhli chybovosti znaků 0,6 % a optimalizovali jsme možné strategie pro ruční korekci chyb a přizpůsobení OCR modelu při zpracování dokumentů s novými fonty a skripty.
    <p>
{% endblock %}