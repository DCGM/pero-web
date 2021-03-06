<!DOCTYPE html>
<html lang="en">

<head>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Projekt PERO</title>

  <link rel="shortcut icon" href="../static/img/favicon.ico">

  <!-- Bootstrap core CSS -->
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

  <!-- Custom fonts for this template -->
  <link href="../static/vendor/fontawesome-free/css/all.css" rel="stylesheet" type="text/css">
  <link href='https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
  <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>


<link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.css" />

  <!-- Custom styles for this template -->
  <link href="../static/css/clean-blog.css" rel="stylesheet">

  <link href="../static/css/custom.css" rel="stylesheet">
  <link href="../static/css/bmod.css" rel="stylesheet">
  <link href="../static/css/hwr.css" rel="stylesheet">

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-70257918-2"></script>
    <script>
      window.dataLayer = window.dataLayer || [];
      function gtag(){dataLayer.push(arguments);}
      gtag('js', new Date());
      gtag('config', 'UA-70257918-2');
    </script>

</head>

<body>
<div id="page-container">
  <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
    <div class="container-fluid">
      <a class="navbar-brand" href="/">Projekt PERO</a>
      <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        Menu
        <i class="fas fa-bars"></i>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a class="nav-link" href="/about">O projektu</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="https://pero-ocr.fit.vutbr.cz">Aplikace PERO-OCR</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/github">GitHub</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/datasets">Datové sady</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="/publications">Publikace</a>
          </li>
          <li class="nav-item">

            <img src="../static/img/czech_republic_flag.png" onclick="setLanguage('cs')" />
            <img src="../static/img/english_flag.png" onclick="setLanguage('en')" />
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Page Header -->
  <header class="masthead" style="background-image: url('../static/img/main-bg.jpg')">
    <div class="overlay"></div>
    <div class="container">
      <div class="row">
        <div class="col-md-10 mx-auto">
          <div class="site-heading">
            <h1>{% block header %}{% endblock %}</h1>
          </div>
        </div>
      </div>
    </div>
  </header>

  <div id="page-content">
    <!-- Main Content -->
    <div class="container main-content">
      <div class="row">
        <div class="col-lg-8 col-md-10 mx-auto">
          <p>
            <b>
              {% block perex %}{% endblock %}
            </b>
          </p>

          {% block content %}{% endblock %}
        </div>
      </div>
    </div>
  </div>

  <!-- Footer -->
<footer class="page-footer font-small">
	<div class="container">
		<div class="row">
			<div class="col-xl-3 offset-xl-3 col-lg-3 offset-lg-3 col-md-3 offset-md-3  col-sm-4 offset-sm-2">
				<p class="text-center">
					<b>Michal Hradiš</b><br />
					FIT VUT v Brně<br />
					ihradis@fit.vut.cz<br />
					+420 541 141 411
				</p>
			</div>

			<div class="col-xl-3 col-lg-3 col-md-3 col-sm-4">
				<p class="text-center">
					<b>Petr Žabička</b><br />
					MZK<br />
					Petr.Zabicka@mzk.cz<br />
					+420 541 646 115
				</p>
			</div>
		</div>

		<div class="text-center">
			<a href="https://www.mzk.cz/"><img src="../static/img/mzk_logo.png" alt="Moravská zemská knihovna v Brně" /></a>
			<a href="https://www.fit.vutbr.cz/"><img src="../static/img/fit_logo.png" alt="Fakulta informačních technologií VUT v Brně" /></a>
			<a href="https://www.mkcr.cz/"><img src="../static/img/mkcr_logo.png" alt="Ministerstvo kultury České republiky" /></a>
		</div>
  	</div>
</footer>
<!-- Footer -->
</div>
  <!-- Bootstrap core JavaScript -->
  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

<script src="https://cdn.jsdelivr.net/gh/fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.js"></script>

  <!-- mdbootstrap -->
  <!script src="../static/vendor/bootstrap/js/mdb.js"></script>
  <!script src="../static/vendor/bootstrap/js/popper.min.js"></script>

  <!-- Custom scripts for this template -->
  <script src="../static/js/clean-blog.min.js"></script>
  <script src="../static/js/custom.js"></script>

</body>

</html>
