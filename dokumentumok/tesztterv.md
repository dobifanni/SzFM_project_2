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

## Elvárt eredmény:
- Kattintáskor a kártya eltűnik.
- Az eltűnés megtörténik, és a rendszer nem dob hibát.


# Teszt 3 – Adatbetöltés és adatmodell integritás

## Cél: 
Ellenőrizni, hogy a különböző Data-osztályok (DoorCardData, EnemyCardData, FloorData) helyesen töltődnek be.

## Előfeltételek: 
Fájlok vagy assetek elérhetők.

## Lépések:
- Játék indítása.
- Nézd meg, hogy minden kártya-típus adatai megjelennek-e a játékban.
- Ellenőrizd, hogy a modellek (DoorCardData, EnemyCardData) adatai megfelelnek a várt értékeknek.

## Elvárt eredmény:
- Az adatok helyesen jelennek meg a UI-ban.
- Nem történik null reference vagy missing data hiba.
