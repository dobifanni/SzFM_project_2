using UnityEngine;

public class StatupGA : GameAction
{
    public StatupCardView StatupCardView { get; private set; }

    public StatupGA(StatupCardView statupCardView)
    {
        StatupCardView = statupCardView;
    }
}
