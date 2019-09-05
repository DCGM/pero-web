{% extends 'template.html.cs' %}

{% block header %}
  Projekt PERO <img src="static/img/brk.png" />
{% endblock %}

{% block content %}
  <h2>Novinky</h2>
  {{ new_posts }}
  <div class="clearfix">
    <a id="all-posts-btn" class="btn btn-primary float-right" href="posts">Všechny příspěvky &rarr;</a>
  </div>
{% endblock %}