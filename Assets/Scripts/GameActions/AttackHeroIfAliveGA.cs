using UnityEngine;

public class AttackHeroIfAliveGA : GameAction
{
    public EnemyCardView Enemy { get; }

    public AttackHeroIfAliveGA(EnemyCardView enemy)
    {
        Enemy = enemy;
    }
}