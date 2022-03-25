{% extends 'template.html.cs' %}

{% block header %}
    Klasifikace historických dokumentů
{% endblock %}

{% block perex %}
    <p>
        Konference <a href="https://icdar2021.org/">ICDAR 2021</a> jsme se nezúčastnili pouze s <a href="/post/2021-05-11_1_ICDAR2021">publikovanými články</a>, ale také jsme se zapojili do soutěže na <a href="https://lme.tf.fau.de/competitions/icdar-2021-competition-on-historical-document-classification/">klasifikaci historických dokumentů</a>.
        Soutěž se skládala ze tří úloh: určování fontu/skriptu, lokalizace a datování dokumentu.
        Ve všech třech úlohách se náš systém umístil na prvním místě a celou soutěž jsme tak vyhráli.
        Článek detailně popisující naše řešení je k dispozici na <a href="https://arxiv.org/abs/2201.09575">arxiv.org</a> a byl také přijat na konferenci <a href="https://das2022.univ-lr.fr/">DAS 2022</a>.
    </p>
{% endblock %}

{% block content %}
    <p>
        Při předzpracování poskytnutých datových sad jsme také vytvořili jejich rozdělení na trénovací a validační část.
        Tato rozdělení společně s krátkým popisem jsou <a href="/hdc_dataset">veřejně k dispozici</a>.
    </p>
{% endblock %}