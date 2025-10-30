using UnityEngine;

public class EnemyCard : Card
{
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public int Speed { get; private set; }

    public EnemyCard(EnemyCardData enemyCardData) : base(enemyCardData)
    {
        Health = enemyCardData.Health;
        Damage = enemyCardData.Damage;
        Speed = enemyCardData.Speed;
    }
}
