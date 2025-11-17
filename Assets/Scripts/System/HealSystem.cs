using System.Collections;
using UnityEngine;
using DG.Tweening;

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
        if (HeroStatSystem.Instance.CurrentHealth + healGA.HealCardView.HealCard.Healing > HeroStatSystem.Instance.MaxHealth)
        {
            
            HeroStatSystem.Instance.CallHPuiUpdate(HeroStatSystem.Instance.CurrentHealth = HeroStatSystem.Instance.MaxHealth);
        }
        else
        {
            HeroStatSystem.Instance.CallHPuiUpdate(HeroStatSystem.Instance.CurrentHealth += healGA.HealCardView.HealCard.Healing);
        }

        yield return new WaitForSeconds(0.55f);

        DestroyCardGA destroyCardGA = new(healGA.HealCardView);
        ActionSystem.Instance.AddReaction(destroyCardGA);
    }
}
