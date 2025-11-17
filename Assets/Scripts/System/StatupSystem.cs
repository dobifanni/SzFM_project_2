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
        if (statupGA.StatupCardView.StatupCard.statType == Stats.DAMAGE)
        {
           HeroStatSystem.Instance.CallDamageuiUpdate(HeroStatSystem.Instance.CurrentDamage += statupGA.StatupCardView.StatupCard.statupAmount);
        }else if(statupGA.StatupCardView.StatupCard.statType == Stats.SPEED)
        {
            HeroStatSystem.Instance.CallSpeeduiUpdate(HeroStatSystem.Instance.CurrentSpeed += statupGA.StatupCardView.StatupCard.statupAmount);
        }
        else if(statupGA.StatupCardView.StatupCard.statType == Stats.MAXHEALTH)
        {
            HeroStatSystem.Instance.CallHPuiUpdate(HeroStatSystem.Instance.MaxHealth += statupGA.StatupCardView.StatupCard.statupAmount);
        }

            yield return new WaitForSeconds(0.5f);

        DestroyCardGA destroyCardGA = new(statupGA.StatupCardView);
        ActionSystem.Instance.AddReaction(destroyCardGA);
    }
}
