using UnityEngine;

public class Card
{
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public int Speed { get; private set; }
    public Sprite Image { get => cardData.Image; }

    private readonly CardData cardData;
    public Card(CardData cardData)
    {
        this.cardData = cardData;
        Health = cardData.Health;
        Damage = cardData.Damage;
        Speed = cardData.Speed;
    }
}
