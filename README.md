# PERO Web

Spuštění serveru:

```python3 server.py --config-file=config.ini```

## Adresářová struktura

```posts```

Tento adresář obsahuje jednotlivé příspěvky, přičemž každý příspěvek má vlastní soubor s připonou ```.py```, ve kterém jsou definovány metainformace a obsah příspěvku. Podrobnější popis těchto souborů je níže.

```static```

Adresář pro statické soubory - především css styly, javascripty, obrázky, případně obsah příspěvku v html.

```templates```

Adresář pro různé šablony. Aktuálně je zde šablona pro celou stránku a šablona pro zobrazení náhledu příspěvku v seznamu.

```Další soubory```

Dále jsou zde také soubory, které definují stránky, které by nejsou příspěvky, ale jsou v nich informace týkající se projektu (např. stránka s odkazy na anotační servery, apod.). Toto jsou opět soubory s příponou ```.py```, které mají obdobnou strukturu strukturu, avšak je možné některé informace vypustit.

## Jak a kam psát příspěvky

Všechny články je nutné umístit do adresáře ```posts```. Pojmenování souborů je libovolné, podmínkou je, aby bylo možné tento soubor dynamicky importovat v rámci hlavního skriptu. Obsah souboru by měl být následující:

```
title = "Název článku"
author = "Autor článku"
date = "31. února 2019"
created = "2019-02-31"
content = "Obsah příspěvku"
```

Obdobně je pak možné doplnit nepovinné atributy, aktuálně ```subtitle``` (podtitulek příspěvku).

V rámci ```title```, ```author```, ```date``` i ```content``` je možné použít libovolných html tagů. Pro jednodušší zápis je také možné definovat obsah v samostatném souboru pomocí html značek. Tento soubor (např. ```obsah_prispevku.html```) je pak potřeba umístit do adresáře ```static/content/``` a odkázat se na něj v rámci atributu ```content = "[obsah_prispevku.html]"```
