using UnityEngine;

public class HealCard : Card
{
    public int Healing { get; private set; }


    public HealCard(HealCardData healCardData) : base(healCardData)
    {
        Healing = healCardData.Healing;
        //Healing = Random.Range(1, 6); //In case we want the heals to be random
    }
}