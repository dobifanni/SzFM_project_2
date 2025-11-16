using UnityEngine;

public class HealGA : GameAction
{
    public HealCardView HealCardView { get; private set; }

    public HealGA(HealCardView healCardView)
    {
        HealCardView = healCardView;
    }
}
