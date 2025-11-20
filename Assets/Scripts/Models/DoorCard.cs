using UnityEngine;

public class DoorCard : Card
{
    public string Description { get; private set; }

    public DoorCard(DoorCardData cardData) : base(cardData)
    {
        Description = cardData.Description;
    }
}
