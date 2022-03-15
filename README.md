# PERO Web

Spuštění serveru:

```python3 server.py --config-file=config.ini```

Aby byl server přístupný z Internetu, pak je nutné změnit v konfiguračním souboru adresu na ```0.0.0.0```.

## Adresářová struktura

```posts```

Adresář pro jednotlivé příspěvky.

```static```

Adresář pro statické soubory - především css styly, javascripty, obrázky, případně obsah příspěvku v html.

```templates```

Adresář pro různé šablony. Aktuálně je zde šablona pro celou stránku a šablona pro zobrazení náhledu příspěvku v seznamu.

```Další soubory```

Dále jsou zde také soubory, jenž definují stránky, které nejsou příspěvky, ale jsou v nich informace týkající se projektu (např. stránka s odkazy na anotační servery, apod.). Toto jsou opět soubory s příponou ```.py```, které mají obdobnou strukturu jako příspěvky, avšak je možné některé informace vypustit.
