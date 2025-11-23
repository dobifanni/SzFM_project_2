# Tesztterv

## Dokumentum célja
Jelen dokumentum célja, hogy definiálja a Unity-ben készült kártyajáték projekt tesztelési elvárásait, tesztelési folyamatát, valamint meghatározza a tesztelési keretrendszert, a tesztelés tárgyát, tesztbázisát és a kilépési feltételeket.

## A teszt tárgya
A teszt tárgya a projekt Scripts könyvtárában található scriptek, amelyek a kártyajáték működéséért felelnek.

A tesztelés fő moduljai:
- Kártya adatmodellek
    - CardData, EnemyCardData, DoorCardData, HealCardData, StatupCardData, stb.
- Játék modell és logika
    - FloorData
    - GameAction osztályok: AttackHeroGA, AttackEnemyGA, HealGA, stb.
- System-ek
    - CardViewSetupSystem, DamageSystem, EnemySystem, stb.
- View és UI komponensek
    - CardViewCreator, EnemyCardViewCreator, stb.
    - HealthUI, SpeedUI, stb.
- Utility és helper osztályok
    - Stats Enum
    - MouseUtil

A tesztelés ezen komponensek működésére és együttműködésére irányul.

## Tesztelési célok
### Funkcionális célok
- A kártyák (Heal, Enemy, Door, StatUp) megfelelő működése
- A hős statjai helyesen változnak
- A GameAction osztályok helyesen végzik:
    - sebzéskalkulációt
    - heal alkalmazását
    - stat növelését
- A Systemek helyes szekvenciában működnek
- A UI elemek megfelelően reagálnak (megfelelően frissül a health, stb.)

### Nemfunkcionális célok
- UI frissítés hibamentes
- Tesztlefedettség megfelelő (kritikus részekre 100%)

## Tesztelési stratégia
### Komponensteszt (Unit test)
- NUnit + Unity Test Runner
- Tesztelendő egységek:
    - adatmodellek
    - GameAction logika
    - utility osztályok

### Integrációs teszt
- Systemek együttműködés
- UI komponensek és logika integrációja

### Rendszerteszt
- A teljes játék logikai körének futtatása (Play Mode teszt)

## Teszteset lista
### Funkcionális tesztesetek
1 - Enemy támadás csökkenti a hős életerejét
- Teszt tárgya: AttackEnemyGA, HeroData
- Tesztadat: hős hp = 10, enemy attack = 3
- Lépések:
    - Inicializáljunk egy hőst 10 HP-val.
    - Hívjuk meg az AttackEnemyGA-t.
- Elvárt eredmény: hős hp = 7
- Kilépési feltétel: HP pontosan a várt értékre csökken.

2 - Enemy támadás nem csökkentheti 0 alá a hős életét
- Teszt tárgya: AttackEnemyGA
- Tesztadat: hős hp = 2, enemy attack = 5
- Lépések:
    - Hős 2 HP-val.
    - Enemy támadás lefuttatása.
- Elvárt eredmény: hős hp = 0
- Kilépési feltétel: HP nem mehet negatívba.

3 - Heal kártya gyógyítja a hőst, de nem lépheti túl a max HP-t
- Teszt tárgya: HealGA, HealCardData, HeroData
- Tesztadat: maxHP = 20, hp = 15, heal = 10
- Lépések: Heal alkalmazása
    - Elvárt eredmény: hp = 20
    - Kilépési feltétel: HP ≤ maxHP

4 - Heal kártya nem okozhat sebzést negatív érték esetén
- Teszt tárgya: HealCardData
- Tesztadat: healAmount = -5
- Lépések: Heal kártya létrehozása
- Elvárt eredmény: rendszer kivételt dob vagy korrigálja 0-ra
- Kilépési feltétel: nincs negatív heal alkalmazás

5 - StatUp kártya növeli a megfelelő statot
- Teszt tárgya: StatupCardData, Stats enum
- Tesztadat: hős atk = 3, statUp = +2
- Lépések: statUp alkalmazása
- Elvárt eredmény: hős atk = 5
- Kilépési feltétel: statérték pontosan nő

6 - DoorCard megfelelően léptet Floor-t
- Teszt tárgya: DoorCardData, FloorSelectSystem, FloorCounterSystem
- Tesztadat: currentFloor = 1
- Lépések: DoorCard használat
- Elvárt eredmény: currentFloor = 2
- Kilépési feltétel: floor index 1-gyel nő

7 - EnemyCardData tartalmaz minden szükséges mezőt
- Teszt tárgya: EnemyCardData
- Tesztadat: name, hp, attack
- Lépések: objektum példányosítása
- Elvárt eredmény: minden mező != null vagy >= 0
- Kilépési feltétel: Data consistency OK

8 - FloorData helyesen tárolja a kártyákat
- Teszt tárgya: FloorData
- Tesztadat: kártya lista
- Lépések: lista inicializálása
- Elvárt eredmény: visszaadáskor értékek változatlanok
- Kilépési feltétel: integrity checked

### Integrációs tesztek
1 - Systemek helyesen szekvenciázzák az eseményeket
- Teszt tárgya: RoundView, EnemySystem, FloorSelectSystem
- Tesztadat: minden kártya eltűnése után floor váltás
- Lépések:
    - Utolsó card elpusztul.
    - Door és NextFloor trigger.
- Elvárt eredmény: új kártyák jelennek meg
- Kilépési feltétel: szekvencia hibátlan

2 - CardViewCreator megjeleníti UI-on a kör kártyáit
- Teszt tárgya: RoundView, CardViewCreator
- Lépések: Lépni egy szintre
- Elvárt eredmény: UI GameObject létrejön, a mezők kitöltődnek
- Kilépési feltétel: UI megfelel a data-nak

3 - GameAction-ek helyesen módosítják Hero + Enemy adatokat
- Teszt tárgya: AttackEnemyGA, AttackHeroGA, HealGA
- Tesztadat: előre definiált hp és atk értékek
- Lépések: több akció egymás után
- Elvárt eredmény: adatsor konzisztens marad
- Kilépési feltétel: final state valid

### UI Tesztek (PlayMode)
1 - Stat Baron Health mindig a Hero HP-t tükrözi
- Teszt tárgya: HealthUI, HeroStatSystem
- Lépések: hős HP változik
- Elvárt eredmény: bar amount megfelelő
- Kilépési feltétel: érték mindig szinkronban

2 - EnemyCardViewCreator a helyes spritet tölti be
- Teszt tárgya: EnemyCardViewCreator
- Tesztadat: EnemyCardData sprite path
- Elvárt eredmény: UI sprite helyesen jelenik meg

### Nemfunkcionális tesztek
1 - Teljesítmény: kártyagenerálás < 50ms
- Teszt tárgya: CardViewCreator
- Lépések: 100 kártya generálása
- Elvárt eredmény: idő < 0.05s
- Kilépési feltétel: határértéken belül

2 - Stabilitás: 30 floor után sem omlik össze a játék
- Teszt tárgya: RoundView
- Lépések: szimulált játék 30 floor-ral
- Elvárt eredmény: nincs memória hiba
- Kilépési feltétel: crash-free run

3 - Prefab dependency-k hiánya esetén értelmes hibaüzenet
- Teszt tárgya: CardViewCreator
- Lépések: hiányzó prefab
- Elvárt eredmény: debug log → egyértelmű hiba
- Kilépési feltétel: no silent failure

## Tesztelési eljárások
- Használati eset alapú tesztek
    - Kártya létrehozása → alkalmazása → eredmény ellenőrzése
    - Harci forduló szimuláció
    - Floor váltás ellenőrzése
    - Hős halála → játék vége esemény
- Ekvivalencia osztályok példák
    - Pozitív sebzés, nulla sebzés, túl nagy sebzés
    - Heal negatív értékkel (invalid input)
    - StatUp kártya többféle statra

## Kilépési feltételek
A teszt lezárható, ha:
- A kritikus komponensekre (RoundView, DamageSystem, GameAction osztályok) a tesztlefedettség ≥ 100%
- A nem kritikus osztályok tesztlefedettsége ≥ 70%
- Nincs “Blocking” vagy “Critical” hiba
- A funkcionális tesztek ≥ 98% MEGFELELT minősítést kapnak

## Kockázatok és függőségek
- Kritikus scriptek logikai hibái dominószerűen minden tesztet érinthetnek
- UI tesztek PlayMode szükségessége miatt időigényesebbek
- Prefab hiány esetén több UI teszt nem fut le

## Teszteléshez szükséges erőforrások
- 1 fejlesztő vagy tesztelő a unit tesztekhez
- 1 tesztelő az integrációs tesztekhez
- Unity Editor + Test Runner