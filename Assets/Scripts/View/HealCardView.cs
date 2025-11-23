using TMPro;
using UnityEngine;

public class HealCardView : CardView
{
    [SerializeField] private TMP_Text healing;

    public HealCard HealCard { get; private set; }

    public void Setup(HealCard card)
    {
        SetSelected(false);

        base.Setup(card);

        HealCard = card;
        healing.text = card.Healing.ToString();
    }
}