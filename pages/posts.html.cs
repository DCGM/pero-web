{% extends 'template.html.cs' %}

{% block header %}
  Všechny příspěvky
{% endblock %}

{% block content %}
  {{ all_posts|safe }}
{% endblock %}