{% extends 'template.html.cs' %}

{% block header %}
  Projekt PERO
{% endblock %}

{% block content %}
    <p>V projektu PERO spolupracuje <a href="http://www.fit.vutbr.cz/">Vysoké učení technické v Brně</a> a
        <a href="https://www.mzk.cz">Moravská zemská knihovna</a> 
        za finanční podpory <a href="https://www.mkcr.cz/?lang=en">Ministerstva kultury České republiky</a>
        v rámci programu NAKI II na podporu aplikovaného výzkumu a vývoje národní a kulturní identity.
    </p>
    <p>
        Cílem projektu je vytvořit technologie a nástroje, které zlepší a rozšíří přístupnost 
        digitalizovaných historických dokumentů odborné i laické veřejnosti. 
        Konkrétně chceme dosáhnout toho, že bude technologicky možné automaticky zpracovat obsah 
        i špatně čitelných a ručně psaných dokumentů na úrovni, která umožní full-textové vyhledávání v rámci jejich obsahu.
        Vyvíjené nástroje využívají nejnovějších poznatků počítačového vidění, strojového učení a zpracování jazyka.
    </p>
    <p>
        Jednotlivými oblastmi výzkumu v projektu je několik aspektů digitalizačních linek: automatická kontrola a 
        zlepšování kvality digitalizátů, automatický přepis textu starších tištěných a nekvalitních dokumentů,
        automatický a polo-automatický přepis ručně psaného textu a automatická extrakce sémantických informací z
        částečně strukturovaných dokumentů, jako jsou například katalogy a matriční knihy.
        Vytvářené nástroje zveřejňujeme jako svobodný a otevřený software a jeho funkčnost ověřujeme 
        při digitalizaci vybraných kolekcí převážně z Moravské zemské knihovny ale i jiných paměťových institucí.
    </p>
{% endblock %}
