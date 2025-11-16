using System.Collections;
using UnityEngine;

public class HealSystem : Singleton<HealSystem>
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<HealGA>(HealPerformer);
        
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<HealGA>();
        
    }

    private IEnumerator HealPerformer(HealGA healGA)
    {
        yield return new WaitForSeconds(2f);

        DestroyCardGA destroyCardGA = new(healGA.HealCardView);
        ActionSystem.Instance.AddReaction(destroyCardGA);
    }
}
