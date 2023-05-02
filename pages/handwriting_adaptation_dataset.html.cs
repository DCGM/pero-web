{% extends 'template.html.en' %}

{% block header %}
  Handwriting Adaptation Dataset
{% endblock %}

{% block content %}

<div class="container">
  <div class="row">
    <div class="col">
      <p>19 manuskriptů v různých Evropských jazycích a stylech písma.</p>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <a class="fancybox" data-fancybox="gallery" rel="ligthbox" href="/static/img/handwriting_adaptation_dataset/handwriting_adaptation_dataset.png" data-caption="&lt;h3&gt;A sample word for each manuscript from HAD.&lt;/h3&gt;">
        <img class="img-fluid" alt="" src="/static/img/handwriting_adaptation_dataset/handwriting_adaptation_dataset.png"/>
      </a>
    </div>
  </div>
  <div class="row">
    <div class="col">
      Podrobnější informace o datasetu a experimentech lze najít
      zde: <a href=https://arxiv.org/abs/2302.06308 target="_blank">Finetuning Is a Surprisingly Effective
      Domain Adaptation Baseline in Handwriting Recognition</a>
    </div>
  </div>
  <div class="row">
    <div class="col">
        &nbsp;
    </div>
  </div>
  <div class="row">
    <div class="col">
      Dataset obsahuje dva adresáře: <b>data</b> a <b>runs</b>.
      <p>
      V adresáři <b>data</b> se nachází obrázky řádků textu a jejich přepisy.
      Řádky byly vyřezány z původních stránek
      třemi způsoby: <i>tight</i>, <i>medium</i>, a <i>wide</i>, jednotlivé typy výřezů se liší velikostí odsazení od
      linky řádku.
      Přepisy jsou v následujícím formátu: ID TRANS, kde ID odpovídá názvu příslušného obázku textového řádku a TRANS je
      samotný přepis.
      </p>
      <p>
      V adresáři <b>runs</b> lze najít rozdělení přepisů pro experimenty provedené v rámci
      odkazovaného <a href=https://arxiv.org/abs/2302.06308 target="_blank">článku</a>, Sekce 5.
      </p>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <h3>Odkazy ke stažení</h3>
        <p>
          <ul>
            <li>Dataset: <a class="dotted-link" href="https://www.fit.vutbr.cz/~ikohut/handwriting_adaptation_dataset/handwriting_adaptation_dataset.zip">stáhnout</a></li>
          </ul>
        </p>
    </div>
  </div>
</div>

{% endblock %}
