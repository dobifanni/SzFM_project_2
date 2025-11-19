using UnityEngine;

public class AttackEnemyGA : GameAction
{
    public EnemyCardView Target { get; }
    public bool HeroActsFirst { get; }

    public AttackEnemyGA(EnemyCardView target, bool heroActsFirst)
    {
        Target = target;
        HeroActsFirst = heroActsFirst;
    }
}
