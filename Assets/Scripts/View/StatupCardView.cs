using TMPro;
using UnityEngine;

public class StatupCardView : CardView
{
    [SerializeField] private TMP_Text statAmount;

    public StatupCard StatupCard { get; private set; }

    public void Setup(StatupCard card)
    {
        SetSelected(false);

        base.Setup(card);

        StatupCard = card;
        statAmount.text = card.statupAmount.ToString();
    }
}
