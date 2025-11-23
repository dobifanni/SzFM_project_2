using UnityEngine;

public class Card
{
    public Sprite Image { get; protected set; }

    protected readonly CardData cardData;

    public Card(CardData cardData)
    {
        this.cardData = cardData;
        Image = cardData.Image;
    }
}
