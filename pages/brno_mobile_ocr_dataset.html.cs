{% extends 'template.html.cs' %}

{% block header %}
Brno Mobile OCR Dataset
{% endblock %}

{% block content %}
<p>
    Brno Mobile OCR Dataset (B-MOD) je kolekcí 2&nbsp;113 šablon (stránky vědeckých článků).
    Pomocí 23 různých mobilních zařízení a bez jakéhokoliv omezení byly nasnímány tyto šablony tak, aby fotografie obsahovaly různé úrovně rozmazání, osvětlení apod.
    Celkově tento dataset obsahuje 19&nbsp;725 fotografií, z nichž bylo získáno 500 tisíc řádků textu s přesnými přepisy.
    Původní šablony jsou rozděleny do tří částí (trénovací, validační a testovací).
</p>
<p>
    <b>Tento dataset je možné použít pouze pro nekomerční výzkumné účely. Pokud cokoliv publikujete na základě tohoto datasetu,
        žádáme vás, abyste uvedli odkaz na článek:</b>
</p>
<p class="intended">
    M. Kišš, M. Hradiš, and O. Kodym, “Brno Mobile OCR Dataset” in <i>2019 15th IAPR International Conference on
    Document Analysis and Recognition (ICDAR)</i>, IEEE, 2019.
</p>
<p>
    Celý dataset si můžete stáhnout níže. Zároveň zde můžete také vyhodnotit váš OCR systém.
    Náš OCR systém je k dispozici na <a href="https://github.com/DCGM/B-MOD">githubu</a>.
    Pokud máte nějaké otázky, kontaktujte ikiss@fit.vutbr.cz nebo ihradis@fit.vutbr.cz.
</p>

<h2>Ke stažení</h2>
<p>
    <ul>
        <li><a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/b-mod/b-mod_templates.zip">Originální šablony</a> (1.45 GB)
        </li>
        <li><a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/b-mod/b-mod_photos_and_xmls_untransformed.zip">Fotografie s přílušnými anotacemi ve formátu PAGE XML</a> (31.62 GB)
        </li>
        <li><a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/b-mod/b-mod_photos_and_xmls_transformed.zip">Zarovnané fotografie s přílušnými anotacemi ve formátu PAGE XML</a> (87.45 GB)
        </li>
        <li><a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/b-mod/b-mod_lines.zip">Vyříznuté řádky s přepisy</a> (5.29 GB)
        </li>
        <li><a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/b-mod/b-mod_photos_devices.txt">Seznam fotografií s názvem použítého zařízení</a> (947 kB)
        </li>
    </ul>
</p>

<h2>Ukázky</h2>
<div class="row">
    <div class="bmod-gallery">
        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/photos/1.jpg" data-caption="&lt;h3&gt;Sample photo #1&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/photos/1.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/photos/2.jpg" data-caption="&lt;h3&gt;Sample photo #2&lt;/h3&gt;">
                <img class="img-responsive" alt="" src="/static/img/bmod/photos/2.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/photos/3.jpg" data-caption="&lt;h3&gt;Sample photo #3&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/photos/3.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/photos/4.jpg" data-caption="&lt;h3&gt;Sample photo #4&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/photos/4.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/rectified/0.jpg" data-caption="&lt;h3&gt;Sample of rectified photo #1&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/rectified/0.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/rectified/1.jpg" data-caption="&lt;h3&gt;Sample of rectified photo #2&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/rectified/1.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/rectified/2.jpg" data-caption="&lt;h3&gt;Sample of rectified photo #3&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/rectified/2.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/rectified/3.jpg" data-caption="&lt;h3&gt;Sample of rectified photo #4&lt;/h3&gt;">
                <img class="img-responsive portrait" alt="" src="/static/img/bmod/rectified/3.jpg"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/lines/easy.png" data-caption="&lt;h3&gt;Samples of easy text lines&lt;/h3&gt;">
                <img class="img-responsive" alt="" src="/static/img/bmod/lines/easy.png"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/lines/medium.png" data-caption="&lt;h3&gt;Samples of medium text lines&lt;/h3&gt;">
                <img class="img-responsive" alt="" src="/static/img/bmod/lines/medium.png"/>
            </a>
        </div>

        <div class="bmod-thumbnail">
            <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/bmod/lines/hard.png" data-caption="&lt;h3&gt;Samples of hard text lines&lt;/h3&gt;">
                <img class="img-responsive" alt="" src="/static/img/bmod/lines/hard.png"/>
            </a>
        </div>
    </div>
</div>

<h2>Vyhodnocení</h2>
<p>
    Váš OCR systém můžete vyhodnotit pomocí formuláře níže.
    Vyplňte vaše jméno nebo jméno vašeho týmu pro následnou identifikaci výsledků
    Prosíme, vyplňte také krátký popis vašeho systému nebo odkaz na jeho popis.
</p>
<p>
    Prosíme, nahrajte jeden textový soubor, kde každý řádek odpovídá jednomu přepsanému řádku testovací sady.
    Tento soubor musí mít stejné formátování, jako soubory použité v trénovací a validační sadě v ZIP archívu "Vyříznuté řádky s přepisy"
    Formátování musí být následující:
</p>
<p class="bmod-intended-monospace">
    obrázek&nbsp;přepis
</p>
<p>
    e.g.
</p>
<p class="bmod-intended-monospace">
    6149958838f466bbb508399a83bbeb5c.jpg_rec_l0004.jpg&nbsp;Theorems 1 and 2 show that, in checking for deadlock or
</p>

<form id="bmod_upload_form" lang="cs" method="POST" action="/brno_mobile_ocr_dataset" enctype="multipart/form-data">
    <p>
    <div class="input-group">
        <input type="text" name="bmod_upload_name" id="bmod_upload_name" class="form-control"
               placeholder="Název (povinné)"/>
        <input type="text" name="bmod_upload_description" id="bmod_upload_description" class="form-control"
               placeholder="Stručný popis (volitelné)"/>
    </div>
    </p>

    <p>
    <div class="input-group">
        <div class="custom-file">
            <input type="file" class="custom-file-input" name="bmod_uploaded_transcription_file"
                   id="bmod_upload_file_input" aria-describedby="bmod_upload_file_input">
            <label class="custom-file-label" id="bmod_upload_label" for="bmod_upload_file_input">Vyberte soubor</label>
        </div>

        <span class="input-group-text" id="bmod_upload_button" onclick="uploadBMODTranscriptionFile()">Nahrát</span>
    </div>
    </p>
</form>

<div id="error_block" {% if success is not defined or success== true %} class="hidden" {% endif %}>
    <p id="bmod_upload_form_no_file_message">Prosím, vyberte nějaký soubor.</p>
    <p id="bmod_upload_form_empty_name_message">Prosím, vyplňte vaše jméno nebo jméno vašeho týmu.</p>

    {% if success is defined and success == false %}
    {% if message is defined and message|length > 0 %}
    <p>{{ message }}</p>
    {% else %}
    <p>Něco neočekávaně selhalo. Prosím, reportujte na ikiss@fit.vutbr.cz.</p>
    {% endif %}
    {% endif %}
</div>

<div id="success_block" {% if success is not defined or success== false %} class="hidden" {% endif %}>
    {% if success is defined and success == true %}
    {% if message is defined and message|length > 0 %}
    <p>{{ message }}</p>
    {% endif %}
    {% endif %}
</div>

<h2>Výsledky</h2>

{% if evaluation_results is defined %}
<div class="table-responsive">
  <table class="table table-hover results">
    <thead>
    <tr>
        <td rowspan="2">Jméno</td>
        <td rowspan="2">Popis</td>
        <td rowspan="2">Datum</td>
        <td colspan="2" class="spanned">Lehké</td>
        <td colspan="2" class="spanned">Střední</td>
        <td colspan="2" class="spanned">Těžké</td>
        <td colspan="2" class="spanned">Celkem</td>
    </tr>
    <tr>
        <td>CER</td>
        <td>WER</td>
        <td>CER</td>
        <td>WER</td>
        <td>CER</td>
        <td>WER</td>
        <td>CER</td>
        <td>WER</td>
    </tr>
    </thead>
    <tbody>
    {% for evaluation_result in evaluation_results %}
    <tr>
        <td>{{evaluation_result.name}}</td>
        <td>{{evaluation_result.description}}</td>
        <td>{{evaluation_result.date}}</td>
        <td>{{evaluation_result.cer_easy}}</td>
        <td>{{evaluation_result.wer_easy}}</td>
        <td>{{evaluation_result.cer_medium}}</td>
        <td>{{evaluation_result.wer_medium}}</td>
        <td>{{evaluation_result.cer_hard}}</td>
        <td>{{evaluation_result.wer_hard}}</td>
        <td>{{evaluation_result.cer_overall}}</td>
        <td>{{evaluation_result.wer_overall}}</td>
    </tr>
    {% endfor %}
    </tbody>
  </table>
</div>
{% else %}
<p>Nebylo možné zpracovat data!</p>
{% endif %}

{% endblock %}
