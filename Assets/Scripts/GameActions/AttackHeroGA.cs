using UnityEngine;

public class AttackHeroGA : GameAction
{
    public EnemyCardView Attacker { get; private set; }

    public AttackHeroGA (EnemyCardView attacker)
    {
        Attacker = attacker;
    }
}
