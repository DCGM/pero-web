{% extends 'template.html.cs' %}

{% block header %}
  Publikace
{% endblock %}

{% block content %}
<div id="publications">
<h3>2022:</h3>
<ul>
    <li>
		<div class="publication">
            <div class="publication-text">
				Kišš, M., Kohút, J., Beneš, K., and Hradiš, M. <span class="publication-emph">Importance of Textlines in Historical Document Classification</span>. In: Uchida, S., Barney, E., Eglin, V. (eds) Document Analysis Systems. DAS 2022. Lecture Notes in Computer Science, vol 13237. Springer, Cham.</i>.
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/2201.09575">arxiv</a>,
                <a class="dotted-link" herp="https://link.springer.com/chapter/10.1007/978-3-031-06555-2_11">Springer</a>,
                <a class="dotted-link" href="/hdc_dataset">dataset</a>
            </div>
        </div>
    </li>
</ul>


<h3>2021:</h3>
<ul>
	<li>
        <div class="publication">
            <div class="publication-text">
            	Kodym, O. and  Hradiš, M. <span class="publication-emph">TG<sup>2</sup>: text-guided transformer GAN for restoring document readability and perceived quality</span>. <i>IJDAR (2021)</i>. https://doi.org/10.1007/s10032-021-00387-z
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/2102.11838v1">arxiv</a>,
                <a class="dotted-link" href="https://link.springer.com/article/10.1007/s10032-021-00387-z">Springer</a>
            </div>
        </div>
    </li>
    <li>
        <div class="publication">
            <div class="publication-text">
            	Kodym, O. and  Hradiš, M. <span class="publication-emph">Page Layout Analysis System for Unconstrained Historic Documents</span>. In: Lladós J., Lopresti D., Uchida S. (eds) Document Analysis and Recognition – ICDAR 2021. ICDAR 2021. Lecture Notes in Computer Science, vol 12822. Springer, Cham.
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/2102.11838v1">arxiv</a>,
                <a class="dotted-link" href="https://link.springer.com/chapter/10.1007/978-3-030-86331-9_32">Springer</a>
            </div>
        </div>
    </li>
    <li>
        <div class="publication">
            <div class="publication-text">
            	Kohút, J. and  Hradiš, M. <span class="publication-emph">TS-Net: OCR Trained to Switch Between Text Transcription Styles</span>. In: Lladós J., Lopresti D., Uchida S. (eds) Document Analysis and Recognition – ICDAR 2021. ICDAR 2021. Lecture Notes in Computer Science, vol 12824. Springer, Cham.
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/2103.05489">arxiv</a>,
                <a class="dotted-link" href="https://link.springer.com/chapter/10.1007/978-3-030-86337-1_32">Springer</a>
            </div>
        </div>
    </li>
    <li>
        <div class="publication">
            <div class="publication-text">
            	Kišš, M., Beneš, K., and Hradiš, M. <span class="publication-emph">AT-ST: Self-Training Adaptation Strategy for OCR</span>. In: Lladós J., Lopresti D., Uchida S. (eds) Document Analysis and Recognition – ICDAR 2021. ICDAR 2021. Lecture Notes in Computer Science, vol 12824. Springer, Cham.
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/2104.13037">arxiv</a>,
                <a class="dotted-link" href="https://link.springer.com/chapter/10.1007/978-3-030-86337-1_31">Springer</a>
            </div>
        </div>
    </li>
</ul>

<h3>2019:</h3>
<ul>
    <li>
        <div class="publication" id="b-mod">
            <div class="publication-text">
            	Kišš, M., Hradiš, M. and Kodym, O. <span class="publication-emph">Brno Mobile OCR Dataset</span>. In: <i>2019 International Conference on Document Analysis and Recognition (ICDAR)</i>. September 2019, p. 1352–1357. ISSN: 1520-5363.
            </div>
            <div class="publication-additional-info">
                <b>Další odkazy:</b>
                <a class="dotted-link" href="https://arxiv.org/abs/1907.01307">arxiv</a>,
                <a class="dotted-link" href="https://github.com/DCGM/B-MOD">github</a>,
                <a class="dotted-link" href="https://ieeexplore.ieee.org/document/8978020">IEEEXplore</a>,
                <a class="dotted-link" href="/brno_mobile_ocr_dataset">dataset</a>
            </div>
        </div>
    </li>
</ul>
</div>
{% endblock %}