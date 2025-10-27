# Teszt 1 – Kártya létrehozás és megjelenítés

## Cél: 
Ellenőrizni, hogy egy kártya-objektum (pl. DoorCard vagy EnemyCard) létrejön-e és megfelelően jelenik meg a képernyőn.

## Előfeltételek: 
A játék elindult, az UI és a CardViewCreator működik.

## Lépések:
- Játék indítása.
- Új kártya generálása (CardViewCreator segítségével).
- Figyeld meg, hogy a kártya megjelenik-e a képernyőn.
- Ellenőrizd, hogy a kártya adatai (DoorCardData, EnemyCardData) helyesen töltődnek-e be (pl. név, típus, értékek).

## Elvárt eredmény:
- A kártya megjelenik.
- Az adatok megegyeznek a modellben tárolt értékekkel.
- Nem jelenik meg hiba az Inspectorban vagy a Console-ban.


# Teszt 2 – Kártya interakció (kiválasztás, mozgatás)

## Cél: 
Ellenőrizni, hogy az egérrel történő interakció (MouseUtil) megfelelően reagál.

## Előfeltételek:
Kártyák megjelennek a képernyőn.

## Lépések:
- Mozgasd az egeret a kártyák fölé.
- Kattints egy kártyára.
- Próbáld meg áthelyezni vagy kijelölni (attól függően, mit enged a rendszer).

## Elvárt eredmény:
- Kiválasztáskor a kártya vizuálisan jelezze az állapotát (pl. highlight).
- A mozgatás vagy kijelölés megtörténik, és a rendszer nem dob hibát.
