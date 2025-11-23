# Követelmény specifikáció

## Jelenlegi helyzet
A játék jelenlegi állapotában már rendelkezésre áll az alapvető játékmeneti struktúra, amely egy kör elrendezésű kártyarendszerre épül. A játékos a kezdéskor kiválaszthatja a hősét, amely meghatározza a kiinduló életerőt, sebzést, és a sebességet. Ezután a játék szintekre bontva halad előre, ahol minden szint egy körben elhelyezett kártyasorból áll. Ezek a kártyák különböző funkciókat látnak el, például ellenséget képviselnek, gyógyítást biztosítanak, vagy statnövelést adnak. A játékos kattintással aktiválhatja bármelyik, felfordított állapotban lévő kártyát, amely azonnal eltűnik, és hatása érvényesül a hősre vagy a játéktérre. A kattintott kártya eltávolítása után felfordulnak az adott lap közvetlen szomszédai, ezzel új lehetőségeket tárva a játékos elé. Amikor az összes kártya eltűnik a pályáról, megjelenik egy ajtó kártya amely a következő szintre léptet tovább. A hős tulajdonságait figyelembe véve az ellenfélkártyák aktiválása során a rendszer levonja az ellenség által okozott sebzést a játékos életerejéből, a gyógyítók növelik azt, a fejlesztők pedig tartós statbónuszokat adnak. Mivel a kártyák random sorrendben jelennek meg egy szinten belül, és speciális szintek is felbukkannak a normál szintek között, így a játékélmény minden újrajátszásnál változik.

## [Üzleti foyamatok modellje](./rendszerterv.md#üzleti-folyamatok-modellje)

## Követelménylista
| Modul | ID | Név | Verzió | Kifejtés | DOD |
|:------|:---|:----|:-------|:---------|:----|
| Játékfelület | K1 | Kezdőmenü | 0.1 | Start és Quit Game gomb megjelenítése; Start indítja a játékot, Quit kilépteti | A gombok láthatók és működésük helyesen végrehajtja a megfelelő navigációt |
| Játékfelület | K2 | Játékmenü UI | 0.1 | Játékfelület megjelenítése; Pause gomb; Pause menü; Combat UI kártyákkal; Hero statok kijelzése | A UI elemek megjelennek és a statok valós időben frissülnek |
| Játék mechanika | K3 | Játékindítás és navigáció | 0.1 | Start → játék; Pause → menü; Continue → folytatás; Return to Menu → kezdőképernyő | Minden menügomb funkció hibátlanul működik és a játék állapota nem sérül |
| Kártyarendszer | K4 | Kártyák kezelése | 0.2 | Kártyák generálása, lefordított állapot, kattinthatóság, felfordulási logika, random sorrend, Combat UI megjelenítés | Minden kártya megfelelő állapotban jelenik meg és kattintható, ha elérhető |
| Szintek | K5 | Szintek és nehézség | 0.2 | Többszintű rendszer, növekvő nehézség, speciális szintek, randomizált megjelenés, Door kártya a szint végén | Szintek között átmenet működik és a randomizálás teljesül |
| Kártyatípusok | K6 | Kártyatípusok | 0.2 | Különböző kártyatípusok megjelenítése és működése (Enemy/Heal/Stat-up/Door) | Mindegyik típus funkciója megfelelően aktiválódik kattintásra |
| Játék mechanika | K7 | Hero rendszer | 0.4 | Hősválasztás különböző statokkal; HP, ATK, SPD kezelése; statváltozások követése | Hősök választhatók, statok változnak és a UI ezt tükrözi |
| Játék mechanika | K8 | Action–Reaction rendszer | 0.6 | Heal, Stat-up és Enemy kártyák reakciói; statok frissítése | Minden reakció megfelelő logikával történik és frissíti a statbart |
| Játék mechanika | K9 | Harcrendszer | 0.6 | Hero támadás; Enemy visszatámadás; harc lezárása; harci animációk | Támadási logika helyes; harci kimenetek megfelelően felülírják a UI-t |
| Játékfelület | K10 | Animációk | 1.0 | Kártyakitétel, felfordulás, kattintási és harci animációk | Minden releváns eseménynél megjelenik a megfelelő animáció |
| Játékfelület/ mechanika | K11 | Win/ Lose rendszerek | 1.0 | A játék végén Win vagy Lose felirat jelenik meg; visszalépés Start menübe | A képernyők megfelelő időben jelennek meg és a gombok működnek |
| Játék mechanika | K12 | Plusz feature bővítések | 2.0 | Loot kártyatípus, Armor stat, Currency, Shop floor, Státusz effektek hozzáadása | Feature-ök helyesen befolyásolják a játékmenetet |
| Játékfelület | K13 | Hangeffektek | 2.0 | Hangeffektek a játék folyamatában, pl. támadásnál, nyereségnél, veszteségnél | Minden eseményhez megfelelő hangeffekt társul |

## [Funkcionális követelmények](./funkspec.md#funkcionális-követelmények)

## [Nemfunkcionális követelmények](./funkspec.md#nemfunkcionális-követemények)

## Vágyálomrendszer

A cél egy egyedi, könnyen tanulható, mégis mély stratégiai élményt nyújtó kártyaalapú roguelite játék fejlesztése Unity-ben. A játékos egy választott hőssel indul, majd különböző szinteken át haladva kártyákra kattintva fedezi fel a pályát: harcba bocsátkozik, gyógyul, és fejleszti a statjait. A kártyák kör alakban helyezkednek el, és minden eltűnő kártya felfedi két szomszédját, így folyamatos felfedezési és döntési helyzetet teremt. A cél minden szinten az összes kártya legyőzése, ezután megjelenik az ajtó, amely a következő pályára vezet.

A hosszú távú vízió egy olyan játék, amely további fejlődési lehetőségeket tartalmaz folyamatos tartalmi bővítéssel. További eleme lehet még a loot kártya, amely különböző statnöveléseket, speciális effekteket vagy tartós bónuszokat biztosítanak a játékos számára. Ezzel párhuzamosan a karakter kaphat egy új védekező értéket, az armort, amely részben vagy teljesen képes felfogni az ellenfelek által okozott sebzést. Az armor működése stratégiai mélységet ad a harcoknak, hiszen a játékosnak meg kell fontolnia, mikor mennyi sebzést vállal fel. Az enemy-k legyőzése után a játékos currency-t kap, melynek használata a shop floor nevű külön szinten válik fontossá, ahol a játékos különböző tárgyakat, statfejlesztéseket vagy gyógyulást vásárolhat. A játékban megjelennek státusz effektek is, például burn vagy poison. Ezek hosszabb távon ható, taktikai elemek, amelyek mind a játékosra, mind az ellenfelekre hatással lehetnek. A vizuális élmény növelése érdekében a játék további animációkat is használhat a már meglévőkön túl: a loot felvétele vagy a gyógyulás. Ezekhez hanghatások is társulhatnak, mint például a támadás hangja, a gyógyulás effekthangja, vagy a kártya felfordulásának jelzése, amely élvezetesebbé teszi a játékfolyamatot.

## Fogalomszótár – Játékkal kapcsolatos fogalmak
### Általános fogalmak
- Hős (Hero): A játékos által választott karakter, aki egyedi statokkal rendelkezik.
- Szint (Floor): A játék egy-egy pályája, ahol a játékos különböző kártyákkal találkozik.
- Kártya (Card): A játék alapvető eleme, amely kattintásra hatását kifejti (enemy, heal, statup, stb.).
- Körkártya-elrendezés: A pálya központi mechanikája, ahol a kártyák kör alakban helyezkednek el, és a kattintott kártya eltűnésével a szomszédos kártyák felfordulnak.
- Statok: A játékos harci és túlélési értékei, pl. életerő, sebzés, sebesség, armor.

### Játékelemek és mechanikák
- Enemy: Egy kártya, amelyre kattintáskor harc indul el; vagy sebzést okoz vagy elpusztul, és legyőzése később currency-t ad.
- Heal: Gyógyító kártya, amely a játékos életét növeli.
- Stat-up: statokat fejlesztő kártya, amelyik típus van rajta, azt fejleszti a hősnek.
- Ajtó (Door): A szint végén megjelenő kártya, amely a következő pályára visz, ha minden más kártyát legyőzött a játékos.
- Loot: Olyan kártya, amely később statnövelést, passzív bónuszt vagy speciális effektet ad a játékosnak.
- Armor: Védelmi stat, amely később csökkenti vagy teljesen blokkolja a beérkező sebzést.
- Státusz effekt (Status Effect): Hosszabb távú pozitív vagy negatív hatás később, pl. poison, burn.

### UI és Menü fogalmak
- Start: A főmenüben található gomb, amely elindítja a játékot.
- Quit Game: Kilépés a játékból.
- Main Menu: A kezdő felület, ahol elérhető a játék indítása, beállítások, kilépés és egyéb opciók.
- Pause menu: Játék közben szüneteltető felület, folytatni lehet a játékot vagy vissza lehet lépni a main menu-be.
- Continue: Folyamatban lévő játék folytatása.
- Return to Game: Paused állapotból visszalépés az aktív játékba, a játék folytatása.

### Erőforrások és gazdaság
- Currency: Olyan játékbeli pénznem, amelyet később az enemy-k legyőzésekor kap a játékos.
- Bolt (Shop Floor): Különleges szint, ahol a játékos később loot-ot, gyógyulást vagy statfejlesztést vásárolhat a currency-ből.

### Harci és játékmenet-fogalmak
- Sebzés (Damage): A játékos vagy az enemy által okozott életerőcsökkenés.
- Kártya felfordulás: Mechanika, amely szerint egy eltűnő kártya után a szomszédai automatikusan felfordulnak és kattinthatóvá válnak.

### Vizuális és hanghatások
- Animáció: A játékban megjelenő mozgó hatások, például kártya felfordulásánál, enemy támadás vagy loot felvétele.
- Hangeffekt: A játék eseményeit kísérő hangok, például kattintás, sebzés hangja vagy gyógyulási effekt.
