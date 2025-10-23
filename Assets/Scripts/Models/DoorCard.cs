using UnityEngine;

public class DoorCard
{
   
    public Sprite Image { get => cardData.Image; }

    private readonly DoorCardData cardData;
    public DoorCard(DoorCardData cardData)
    {
        this.cardData = cardData;
    }
}
