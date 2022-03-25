{% extends 'template.html.en' %}

{% block header %}
  Klasifikace historických dokumentů
{% endblock %}

{% block content %}
<p>
    V rámci soutěže na klasifikaci historických dokumentů na ICDAR 2021 (<a href="https://lme.tf.fau.de/competitions/icdar-2021-competition-on-historical-document-classification/">ICDAR 2021 Competition on Historical Document Classification</a>) jsme vytvořili vlastní rozdělení datových sad.
    V odkazech níže naleznete anotační soubory, které jsme použili.
    Dataset pro určování skriptu (typu ručně psaného písma), který byl pro tuto soutěž poskytnut, se skládal ze dvou dříve publikovaných datasetů, u kterých jsme sjednotili ground-truth.
</p>
<p>
    Každý soubor obsahuje na jednotlivých řádcích anotace vždy k jednomu dokumentu (stránce) v datové sadě.
    Na začátku každého řádku je nejprve název dané stránky a za první mezerou se nacházejí mezerami oddělené anotace.
    V případě datování jsou anotace ve formátu "ne-před ne-po", které určují interval let, ve kterých dokument vznikl.
    Při lokalizaci je anotací pro každý dokument název místa, kde dokument vznikl.
    Pro určování fontu a skriptu je nejprve anotován hlavní font/skript a následuje výčet dalších, které se v daném dokumentů vyskytují.
</p>

<h3>Odkazy pro stažení</h3>
<p>
    <ul>
    <li>Font: <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/font.trn">font.trn</a> (2.1 MB), <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/font.val">font.val</a> (13 KB)</li>
    <li>Skript: <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/script.trn">script.trn</a> (232 KB), <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/script.val">script.val</a> (14 KB)</li>
    <li>Lokace: <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/location.trn">location.trn</a> (250 KB), <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/location.val">location.val</a> (3.1 KB)</li>
    <li>Datum: <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/date.trn">date.trn</a> (325 KB), <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikiss/hdc_2021/date.val">date.val</a> (32 KB)</li>
    </ul>
</p>

<h3>Příklady anotací</h3>
<table class="table">
  <thead>
    <tr>
      <th scope="col">Úloha</th>
      <th scope="col">Formát anotace</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">Font a skript</th>
      <td><p class="bmod-intended-monospace">IRHT_P_001909.tif Semihybrida Textualis</p></td>
    </tr>
    <tr>
      <th scope="row">Lokace</th>
      <td><p class="bmod-intended-monospace">b27efa208a95f5da6b877bec7608e23a.jpg Fonteney</p></td>
    </tr>
    <tr>
      <th scope="row">Datum</th>
      <td><p class="bmod-intended-monospace">3545_1100_1199.jpg 1100.0 1199.0</p></td>
    </tr>
  </tbody>
</table>
{% endblock %}
