# Követelmény specifikáció

## Jelenlegi helyzet
A játék jelenlegi állapotában már rendelkezésre áll az alapvető játékmeneti struktúra, amely egy kör elrendezésű kártyarendszerre épül. A játékos a kezdéskor kiválaszthatja a hősét, amely meghatározza a kiinduló életerőt, sebzést, és a sebességet. Ezután a játék szintekre bontva halad előre, ahol minden szint egy körben elhelyezett kártyasorból áll. Ezek a kártyák különböző funkciókat látnak el, például ellenséget képviselnek, gyógyítást biztosítanak, vagy statnövelést adnak. A játékos kattintással aktiválhatja bármelyik, felfordított állapotban lévő kártyát, amely azonnal eltűnik, és hatása érvényesül a hősre vagy a játéktérre. A kattintott kártya eltávolítása után felfordulnak az adott lap közvetlen szomszédai, ezzel új lehetőségeket tárva a játékos elé. Amikor az összes kártya eltűnik a pályáról, megjelenik egy ajtó kártya amely a következő szintre léptet tovább. A hős tulajdonságait figyelembe véve az ellenfélkártyák aktiválása során a rendszer levonja az ellenség által okozott sebzést a játékos életerejéből, a gyógyítók növelik azt, a fejlesztők pedig tartós statbónuszokat adnak. Mivel a kártyák random sorrendben jelennek meg egy szinten belül, és speciális szintek is felbukkannak a normál szintek között, így a játékélmény minden újrajátszásnál változik.

## [Üzleti foyamatok modellje](./rendszerterv.md#üzleti-folyamatok-modellje)

## Követelménylista
| Modul | ID | Név | Verzió | Kifejtés | Megjegyzés |
|:------|:---|:----|:-------|:---------|:-----------|
| Játékfelület | K1 | Kezdőoldal kialakítása | 0.1 | A játék kezdőoldala a Start és Quit Game gombbal | - |
| Játékfelület | K2 | Start gomb | 0.1 | Start gomb megjelenítése Start menu-ben | - |
| Játék mechanika | K3 | Start gomb működése | 0.1 | Start gomb működésének implementálása | Rákattintva elindul a játék |
| Játékfelület | K4 | Quit game gomb | 0.1 | Quit game gomb megjelenítése a Start menu-ben | - |
| Játék mechanika | K5 | Quit game gomb működése | 0.1 | Quit game gomb működésének implementálása | Rákattintva kilép a játékból |
| Játékfelület | K6 | Játék oldalának kialakítása | 0.1 | A Start gomb megnyomása után a játékra irányított felület kialakítása | - |
| Játékfelület | K7 | Pause menu gomb | 0.1 | Pause menu gomb megjelenítése a játék felületén | - |
| Játék mechanika | K8 | Pause menu gomb működése | 0.1 | Pause menu gomb működésének implementálása | Rákattintva szünetel a játék és megjelenik egy menu |
| Játékfelület | K9 | Continue gomb | 0.1 | Continue gomb megjelenítése a Pause menu-n belül | - |
| Játék mechanika | K10 | Continue gomb működése | 0.1 | Continue gomb működésének implementálása | Rákattintva a játék folytatódik |
| Játékfelület | K11 | Return to menu gomb | 0.1 | Return to menu gomb megjelenítése a Pause menu-n belül | - |
| Játék mechanika | K12 | Return to menu gomb működése | 0.1 | Return to menu gomb működésének implementálása | Rákattintva visszatér a kezdő menu-be |
| Játék mechanika | K13 | Kártyák generálása | 0.1 | Kártyák generálása a megadott szinten | - |
| Játék mechanika | K14 | Kártyák kattinthatósága | 0.1 | Kártyák kattinthatósága, majd eltűnése | Később nemcsak eltűnnek, hanem reactiont-t váltanak ki |
| Játékfelület | K15 | Kártyák megjelenítése | 0.2 | Kártyák megjelennek a Combat menu-ben a játék elindítása után | - |
| Játék mechanika | K16 | Kártyák fordulása | 0.2 | Kártyák lefordítva jelennek meg, majd felfordulnak ha a szomszédos kártya elpusztult | Mindig a felfordult kártyák kattinthatóak csak |
| Játék mechanika | K17 | Szintek kialakítása | 0.2 | Különböző szintek kialakítása | A nehézségük fokozatosan növekszik |
| Játék mechanika | K18 | Enemy kártyatípus hozzáadása | 0.2 | Ellenség kártyák megtervezése és hozzáadása a szintekhez | A legyőzési nehézségük fokozatosan növekszik |
| Játék mechanika | K19 | Heal kártyatípus hozzáadása | 0.2 | Gyógyulás kártyák megtervezése és hozzáadása a szintekhez | A gyógyulás mennyisége fokozatosan növekszik |
| Játék mechanika | K20 | Stat-up kártyatípus hozzáadása | 0.2 | Stat fejlesztő kártyák megtervezése és hozzáadása a szintekhez | A különböző stat-okat fejleszti a játékosnak (health, speed, attack) |
| Játék mechanika | K21 | Door kártyatípus hozzáadása | 0.2 | Ajtó kártyák megtervezése és hozzáadása a szintekhez | A különböző ajtók más szintekre visznek tovább |
| Játék mechanika | K22 | Door kártya megjelenése | 0.2 | Ajtó kártya megjelenítése a szint végén | Megjelenik miután elpusztult minden kártya |
| Játék mechanika | K23 | Door kártya funkció | 0.2 | Az ajtó kártyára kattintva átvisz a megfelelő következő szintre | Különböző ajtók más szintekre visznek |
| Játék mechanika | K24 | Hero stat-ok implementálása | 0.4 | A játékosnak van élete, támadása és sebessége | A kezdésnél majd a választható hero szerint mások az adatok |
| Játék mechanika | K25 | Hero kiválasztása | 0.4 | Különböző Hero-ból lehet választani a kezdésnél | A Hero típusoknál más-más stat-ok erősebbek vagy gyengébbek kezdésnél, majd ezt lehet fejleszteni Stat-up kártyákkal |
| Játékfelület | K26 | Hero stat-ok megjelenítése a Combat menu-ben | 0.4 | Játékos élete, támadása és sebessége felületen a játék közben folyamatosan megjelenítve a felhasználónak | A kezdésnél kiválasztott hero szerint más adatok vannak megjelenítve |
| Játék mechanika | K27 | Action-Reaction system kialakítása | 0.4 | A játék eseményei reakciókat váltsanak ki | Enemy, Heal, Stat-up kártyákra |
| Játék mechanika | K28 | Heal Action | 0.4 | A Heal kártyára kattintva a hős gyógyul | - |
| Játék mechanika | K29 | Stat-up Action | 0.4 | A Stat-up kártyára kattintva a hős stat-ok módosulnak a típus alapján | - |
| Játék mechanika | K30 | Attack Action | 0.4 | Az Enemy kártyára kattintva a hős megtámadja az ellenséget | - |
| Játék mechanika | K31 | Enemy Attack Action | 0.4 | Az Enemy kártyára kattintva a hős megtámadja az ellenséget, és a stat-oknak megfelelően visszatámad az ellenség ha nagyobb | - |
| Játék mechanika | K32 | Hero stat-ok változása | 0.4 | A játék eseményeit leköveti a Stat bar | Action-reaction system része |
| Játék mechanika | K33 | Speciális szintek | 0.6 | Különböző speciális szintek hozzáadása | Speciális, alap szintektől eltérő, pl. több Heal kártya |
| Játék mechanika | K34 | Speciális szintek random megjelenítése | 0.6 | Különböző speciális szintek random jelennek meg a szintek között | Százalékosan történik a bizonyos szintek randomizálása |
| Játék mechanika | K35 | Random kártya spawn | 0.6 | A kártyák random sorrendben jelennek meg egy szinten belül | Ezzel minden újrajátszásnál más lesz a kimenete a játéknak |
| Játékfelület | K36 | Win felirat | 0.8 | Játék végén Win felirat megjelenik | Ezután vissza lehet lépni a Start menu-be |
| Játékfelület | K37 | Lose felirat | 0.8 | Játékos halála után Lose felirat megjelenik | Ezután vissza lehet lépni a Start menu-be |
| Játékfelület | K38 | Loot kártyatípus hozzáadása | 2.0 | Különböző Loot kártyák hozzáadása a szintekhez | - |
| Játék mechanika | K39 | Loot kártya funkció | 2.0 | Loot kártya funkció implementálása | Stat-okat erősítenek, vagy speciális effekteket adnak a játékosnak |
| Játékfelület | K40 | Armor stat hozzáadása | 2.0 | Az Armor plusz stat-ként hozzáadása játékosnak | - |
| Játék mechanika | K41 | Armor funkció | 2.0 | Armor funkció implementálása | Enemy támadásnál bizonyos mennyiséget kivéd |
| Játék mechanika | K42 | Currency | 2.0 | Currency bevezetése enemy-k legyőzésére | Enemy-k legyőzése után kapunk bizonyos currency-t |
| Játék mechanika | K43 | Shop floor | 2.0 | Bolt szint ahol lehet vásárolni loot-ot vagy heal-t | Currency-vel lehet fizetni |
| Játékfelület | K44 | Státusz effektek | 2.0 | Státusz effektek implementálása | pl. burn, poison |
| Játékfelület | K45 | Animációk | 2.0 | Animációk a játék folyamatában | pl. kártyakitétel a szintre, kattintásnál effekt |
| Játékfelület | K46 | Hangeffektek | 2.0 | Hangeffektek a játék folyamatában | pl. támadásnál, nyereségnél, veszteségnél |

## Szabad riport

## Irányított riport

## Vágyálomrendszer

A cél egy egyedi, könnyen tanulható, mégis mély stratégiai élményt nyújtó kártyaalapú roguelite játék fejlesztése Unity-ben. A játékos egy választott hőssel indul, majd különböző szinteken át haladva kártyákra kattintva fedezi fel a pályát: harcba bocsátkozik, gyógyul, és fejleszti a statjait. A kártyák kör alakban helyezkednek el, és minden eltűnő kártya felfedi két szomszédját, így folyamatos felfedezési és döntési helyzetet teremt. A cél minden szinten az összes kártya legyőzése, ezután megjelenik az ajtó, amely a következő pályára vezet.

A hosszú távú vízió egy olyan játék, amely a látványos animációkat, és fejlődési lehetőségeket tartalmaz folyamatos tartalmi bővítéssel. További eleme lehet még a loot kártya, amely különböző statnöveléseket, speciális effekteket vagy tartós bónuszokat biztosítanak a játékos számára. Ezzel párhuzamosan a karakter kaphat egy új védekező értéket, az armort, amely részben vagy teljesen képes felfogni az ellenfelek által okozott sebzést. Az armor működése stratégiai mélységet ad a harcoknak, hiszen a játékosnak meg kell fontolnia, mikor mennyi sebzést vállal fel. Az enemy-k legyőzése után a játékos currency-t kap, melynek használata a shop floor nevű külön szinten válik fontossá, ahol a játékos különböző tárgyakat, statfejlesztéseket vagy gyógyulást vásárolhat. A játékban megjelennek státusz effektek is, például burn vagy poison. Ezek hosszabb távon ható, taktikai elemek, amelyek mind a játékosra, mind az ellenfelekre hatással lehetnek. A vizuális élmény növelése érdekében a játék animációkat is használhat: a kártyák megjelenése, eltűnése, a támadások, a loot felvétele vagy a gyógyulás. Ezekhez hanghatások is társulhatnak, mint például a támadás hangja, a gyógyulás effekthangja, vagy a kártya felfordulásának jelzése, amely élvezetesebbé teszi a játékfolyamatot.

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