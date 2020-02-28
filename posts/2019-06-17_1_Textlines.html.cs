{% extends 'template.html.cs' %}

{% block header %}
    Detekce řádků v dokumentech
{% endblock %}

{% block perex %}
    <p>Tento příspěvek stručně představuje postup pro extrakci řádků textu použité v projektu.</p>
{% endblock %}

{% block content %}
    <img class="img-fluid" src="/static/img/textline_extraction.png" alt="Textline extraction parses the document page so that its content can be analysed by OCR"/>
    <p>
        Před použitím rozpoznávání textu, je třeba efektivně detekovat a extrahovat řádky textu na dané stránce dokumentu.
        Pro úplnou lokalizaci textového řádku jsou zapotřebí dvě informace.
        Zaprvé jsou to souřadnice <i>základní linie (baseline)</i> určujíci umístění řádku a zadruhé to je <i>výška</i> písma nad a pod onou linií.
        Tyto informace specifikují oblast, která musí být oříznuta, aby obsahovala všechny informace, aniž by došlo k překročení do sousedních řádků.
        Následně lze snadno spočítat ohraničení celého řádku, které je vhodné zvláště při práci se standardním formátem
        <a href="https://www.primaresearch.org/schema/PAGE/gts/pagecontent/2016-07-15/Simple%20PAGE%20XML%20Example.pdf">PAGE XML</a>.
    </p>
    <img class="img-fluid" src="/static/img/textline_lines.png" alt="To extract a document textline, suitable representation has to be be chosen"/>
    <p>
        Pro efektivní predikci těchto hodnot na stránce vstupního dokumentu používáme konvoluční neuronovou síť s architekturou kodér-dekodér.
        Aby byla zachována robustnost napříč různými rozloženími stránek a velikostí písma, analyzuje síť obrázek stránky ve třech různých rozlišeních.
		Jak je vidět na obrázku níže, v každém kroce je výstup z předchozího kroku spojen s aktuálním vstupem.
    </p>
    <p>
        Na výstupní vrstvě sítě jsou pro každý pixel předpovídány tři hodnoty - pravděpodobnost, že pixel obsahuje základní linii, a odhadovaná výška písma nad a pod základní linkou.
        Mapy pravděpodobnosti základní linie jsou poté zpracovány pomocí jednoduchého prahování a analýzy spojených komponent.
		Výšky písma pro každou detekovanou linku se pak počítají jako medián predikcí výšky na odpovídajících pixelech základní linky.
    </p>
    <img class="img-fluid" src="/static/img/textline_architecture.png" alt="Architecture of the neural network used for textline detection"/>
    <p>
    	Existují však případy, kdy je obraz naskenované stránky směrem ke hřbetu zdeformovaný, či řádek ručně psaného písma zakřivený.
        V takových případech jednoduché oříznutí pomocí ohraničení řádku vede k výřezům, které obsahují více než jeden řádek textu, což není pro rozpoznávání textu vhodné.
        Z tohoto důvodu je jako další krok zpracování provedeno rozvinutí textového řádku pomocí normál detekované základní linie, což elasticky transformuje obraz daného řádku.
    </p>
    <img class="img-fluid" src="/static/img/textline_unfolding.png" alt="Detected textline may need to be unfolded before cropping"/>
    <p>
    	Díky tomu mohou být dokonce i neoptimálně naskenované stránky dokumentu s náročným rozvržením a řadou různých typů písma a nadpisů plně automaticky analyzovány a mohou z nich být vyříznuty řádky textu.
    </p>
{% endblock %}
