Irányítás:
A/D: balra/jobbra mozgás
W/Space: felfele ugrás
Q/E: balra/jobbra ugrás
S: csak a kifele mutató sebesség meghagyása

Kamera:
Görgõ: nagyítás
Középsõ klikk: kamera le-/visszacsatolása

Pályaszerkesztõ:
Bal/jobb klikk: be-/kikapcsolás
Bal klikk másodszor: blokk lehelyezése
Jobb klikk a blokkon: blokk törlése
Shift + bal klikk: gyûrû lehelyezése
P: mentés
O: betöltés

Unity bûvészkedés:
Pálya véglegesítése: Level Root kimásolása (Ctrl+C) a futó játékból, beillesztése (Ctrl+V) a leállított játékba. Bizonytalanság esetén elõtte érdemes menteni a pályát (P).
Kamera inerciába helyezése: a Hierarchy-ban a Background GameObjectben lévõ Inertial Camera bekapcsolása (Inspector bal felsõ pipája), és a Player (kapszula) Main Camerájának kikapcsolása.
Ugrás/séta sebességének változtatása: a Player Crude Controller komponensében (Inspector ablak).
Állomás paraméterei: (Hierarchy-ban) a Force Fieldnek a Uniform Rotation Field komponense
Rács beosztása: (Hierarchy-ban) a Level Editor Level Editor komponensében.