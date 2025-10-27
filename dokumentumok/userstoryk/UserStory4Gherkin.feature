Scenario: Player elindítja a játékot
    Given a CardCreator legenerálta a kártyákat
    When a Player elindítja a játékot
    Then generált kártyák random válaszottan loot,heal,enemy
