using UnityEngine;

public class EnemyCard
{
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public int Speed { get; private set; }
    public Sprite Image { get => cardData.Image; }

    private readonly EnemyCardData cardData;
    public EnemyCard(EnemyCardData cardData)
    {
        this.cardData = cardData;
        Health = cardData.Health;
        Damage = cardData.Damage;
        Speed = cardData.Speed;
    }
}
