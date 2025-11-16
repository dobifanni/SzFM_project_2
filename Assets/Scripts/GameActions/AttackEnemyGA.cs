using UnityEngine;

public class AttackEnemyGA : GameAction
{
    public EnemyCardView Target { get; }
    

    public AttackEnemyGA(EnemyCardView target)
    {
        Target = target;
    }
}
