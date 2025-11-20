using UnityEngine;

public class StatupCard : Card
{
    public Stats statType { get; private set; }
    public int statupAmount { get; private set; }


    public StatupCard(StatupCardData statupCardData) : base(statupCardData)
    {
        statType = statupCardData.StatType;
        statupAmount = statupCardData.Amount;
    }
}