{% extends 'template.html.cs' %}

{% block header %}
  Ručně psaný dataset
{% endblock %}

{% block content %}
    <p>
        Pro vývoj automatického přepisu historických dokumentů potřebujeme ukázky písma od co nejvíce autorů, a proto se neobejdeme bez vaší pomoci.
        Prosím, stáhněte si vzorové stránky textu pomocí tlačítka níže, vytiskněte si je a přepište vzorový text.
    </p>

	<div class="input-default-wrapper mt-5">
		<div class="input-group">
			<div class="input-group-text mb-3" id="hwr_get_button" onclick="getRandomHandwrittenPage()">Stáhnout vzorové stránky</div>
		</div>
	</div>

	<p>
		Každá stránka obsahuje jiný text a opakovaným stažením získáte jiné unikátní stránky. Prosím, nepřepisujte jednu stránku několikrát.
		Můžete přepsat několik stránek, ale nejvíce nám pomůžete, pokud seženete co nejvíce různých "pisatelů". Zachovejte řádkování i případné pravopisné chyby.
		Ukázka vhodného přepisu je níže.
    </p>

	<hr />

	<p>
        Přepsané stránky prosím naskenujte pomocí skeneru a nahrajte je pomocí formuláře níže, nebo je zašlete na e-mail ihradis@fit.vutbr.cz s předmětem "Brno HWR dataset".
        Alternativně můžete zaslat fyzické listy papíru poštou na adresu Michal Hradiš, Fakulta informačních technologií VUT v Brně, Božetěchova 1/2, 612 00 Brno.
        Zasláním přepsaných stránek souhlasíte s jejich anonymním zveřejněním a s jejich dalším použitím bez omezení.
    </p>

    <form id="handwritten_dataset_form" lang="cs" action="/handwritten_dataset" method="POST" enctype="multipart/form-data">
		<div class="input-group">
			<div class="custom-file">
				<input type="file" class="custom-file-input" name="hwr_uploaded_files" id="hwr_upload_file_input" aria-describedby="hwr_upload_file_input" multiple>
				<label class="custom-file-label" id="hwr_upload_label" for="hwr_upload_file_input">Vybrat soubor</label>
			</div>

			<span class="input-group-text" id="hwr_upload_button" onclick="uploadHandwrittenPages()">Nahrát</span>
		</div>
    </form>

    <div id="error_block" {% if success is not defined or success == true %} class="hidden" {% endif %}>
        <p id="hwr_upload_form_no_file_message">Prosím, vyberte nějaké soubory k nahrání.</p>
        {% if success is defined and success == false %}
            {% if message is defined and message|length > 0 %}
                <p>{{ message }}</p>
            {% else %}
                <p>Něco neočekávaně selhalo. Prosím, reportujte na ikiss@fit.vutbr.cz.</p>
            {% endif %}
        {% endif %}
    </div>

    <div id="success_block" {% if success is not defined or success == false %} class="hidden" {% endif %}>
        {% if success is defined and success == true %}
            {% if message is defined and message|length > 0 %}
                <p>{{ message }}</p>
            {% else %}
                <p>Soubory úspěšně uloženy. Děkujeme za přispění.</p>
            {% endif %}
        {% endif %}
    </div>

    <h3>Ukázka přepsané stránky</h3>
    <p>
        <a href="/static/img/hwr_example.jpg" target="_blank">
            <img class="img-fluid border border-secondary" src="/static/img/hwr_example.jpg" alt="Example of transcribed page."/>
        </a>
    </p>

    <p>
        Naší snahou je získat velkou databází ručně přepsaných stránek textu, s cílem vytvořit nástroj pro autmatické přepisování českých historických dokumentů.
        Abychom byli schopni zachytit co největší variabilitu ručně psaného písma, potřebujeme vzorky od co nejvíce autorů.
        Ať už přepíšete jednu nebo deset stránek a věnujete nám je, výrazně zlepšíte možnosti vyhledávání v obsahu historických dokumentů.
        Naším cílem je zpřístupnit vyhledávání v textech kronik, matrikách, katastrech, historické korespondenci a podobně.
    </p>

{% endblock %}
