# Rendszerterv

## Projektterv

### Csapattagok
- Ujj Ádám: Tervező és programozó
- Varga Szabolcs: Designer és programozó
- Dobi Fanni: Tesztelő és programozó

### Szerepkörök

- Tervező:
- Tesztelő: 
- Designer:

### Ütemterv és mérföldkövek
#### Sprint 1 – Fejlesztés
- Játék alapstruktúrájának kialakítása: kártyák és főmenü
- Backend: Unity mappa struktúra létrehozása és addonok telepítése
#### Sprint 2 – Fejlesztés
- Játékbeli kártya megjelenítése
- Főmenüből játékmenet indítása
- Játékmenetben Pause menü és gombjai, ezek funkcionálása
- Mérföldkő: a játék és főmenü közötti szabadon lépkedés

## Fizikai környezet
Fizikai környezet alapján a rendszer bontható két részre.
### Backend
A backend a játék logikai és rendszeroldali rétege, amely biztosítja az egyes rendszerek (pl. kártyakezelő, játékos-statisztikák, mentési rendszer, event manager) működését. Ez a rész C# nyelven, önálló Unity-scriptek és komponensek formájában valósul meg, egységekbe rendezve az adott funkciók szerint (pl. külön szkriptek a kártyák logikájához, a pontszámítási rendszerhez vagy a játékállapot-kezeléshez). A rendszeradatokat lokális szinten, ScriptableObjectekben vagy JSON alapú tárolókban kezeljük, így nincs szükség külön szerverre vagy külső adatbázisra. A moduláris felépítés lehetővé teszi, hogy új funkciókat vagy addonokat külön komponensként építsünk be anélkül, hogy a meglévő rendszert módosítanunk kellene.
### Frontend
A frontend a játék vizuális és interaktív felülete, amelyet a Unity motor jelenít meg. Ide tartozik a főmenü, a játékmező, valamint a kártyák és UI-elemek kezelése. A Unity UI-rendszerét (UGUI) használjuk a felhasználói felület elemeinek megjelenítésére és kezelésére, az animációkhoz pedig a Unity Animation vagy DOTween megoldásokat alkalmazzuk. A frontend és a backend szorosan együttműködik: a backend szolgáltatja a szükséges adatokat és logikát, míg a frontend ezeket látványosan, játékosbarát módon jeleníti meg.

## Funkcionális terv

Rendszerszereplők:

## Architekturális terv
### Frontend
Az alábbi fő komponensekből épül fel:

### Backend
Az architektúra fő elemei a következők:

## Üzleti folyamatok modellje

## Tesztterv
