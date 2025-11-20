using UnityEngine;
using DG.Tweening;

public class StatupGA : GameAction
{
    public StatupCardView StatupCardView { get; private set; }

    public StatupGA(StatupCardView statupCardView)
    {
        StatupCardView = statupCardView;
        StatupCardView.transform.DOScaleY(0f, 0.35f);
    }
}
