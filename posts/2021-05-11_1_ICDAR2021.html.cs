{% extends 'template.html.cs' %}

{% block header %}
    Příspěvky na ICDAR 2021
{% endblock %}

{% block perex %}
    <p>
		V září 2021 proběhne <a href="https://icdar2021.org/">16. ročník International Conference on Document Analysis and Recognition</a> (ICDAR) ve švýcarském Lausanne.
        V rámci projektu PERO jsme na tuto konferenci poslali tři příspěvky a všechny tři byly také přijaty.
    </p>
{% endblock %}

{% block content %}
    <p>
        Prvním odeslaným článkem je článek o <a href="https://arxiv.org/abs/2102.11838v1">detekci řádků textu pomocí modelu neuronové sítě nazvané ParseNet</a>.
        Druhý článek je zaměřen na možnost <a href="https://arxiv.org/abs/2103.05489">přepínat mezi různými výstupy rozpoznávače textu založeného na neuronové síti pomocí Transcription-Style bloku</a>.
        Poslední článek představuje <a href="https://arxiv.org/abs/2104.13037">strategii pro efektivní využití velkého množství neanotovaných dat z cílové domény</a> při trénování rozpoznávače textu.
    </p>
{% endblock %}