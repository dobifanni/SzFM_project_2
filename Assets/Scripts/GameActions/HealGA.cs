using UnityEngine;
using DG.Tweening;

public class HealGA : GameAction
{
    public HealCardView HealCardView { get; private set; }

    public HealGA(HealCardView healCardView)
    {
        HealCardView = healCardView;
        HealCardView.transform.DOMove(new Vector3(0, 0, 0), 0.3f).OnComplete(() => {HealCardView.transform.DOScaleX(0f, 0.25f);});
    }
}
