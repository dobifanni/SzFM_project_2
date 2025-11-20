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

    // apply damage on the model
    public void ApplyDamage(int amount)
    {
        Health = Mathf.Max(0, Health - Mathf.Max(0, amount));
    }
}
