using UnityEngine;
using System.Collections;

public class StatupSystem : Singleton<StatupSystem>
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<StatupGA>(StatupPerformer);

    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<StatupGA>();

    }

    private IEnumerator StatupPerformer(StatupGA statupGA)
    {
        yield return new WaitForSeconds(2f);

        DestroyCardGA destroyCardGA = new(statupGA.StatupCardView);
        ActionSystem.Instance.AddReaction(destroyCardGA);
    }
}
