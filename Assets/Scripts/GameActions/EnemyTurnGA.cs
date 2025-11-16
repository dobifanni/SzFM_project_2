using UnityEngine;

public class EnemyTurnGA : GameAction
{
    public EnemyCardView Target { get; }

    public EnemyTurnGA(EnemyCardView target)
    {
        Target = target;
    }
}
