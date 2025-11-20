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
        var card = statupGA.StatupCardView.StatupCard;
        if (card.statType == Stats.DAMAGE)
        {
            HeroStatSystem.Instance.CurrentDamage += card.statupAmount;
            HeroStatSystem.Instance.CallDamageuiUpdate(HeroStatSystem.Instance.CurrentDamage);
        }
        else if (card.statType == Stats.SPEED)
        {
            HeroStatSystem.Instance.CurrentSpeed += card.statupAmount;
            HeroStatSystem.Instance.CallSpeeduiUpdate(HeroStatSystem.Instance.CurrentSpeed);
        }
        else if (card.statType == Stats.MAXHEALTH)
        {
            // Increase only MaxHealth; do NOT heal current HP
            HeroStatSystem.Instance.MaxHealth += card.statupAmount;
            HeroStatSystem.Instance.CallHPuiUpdate(HeroStatSystem.Instance.CurrentHealth);
        }

        yield return new WaitForSeconds(0.5f);

        DestroyCardGA destroyCardGA = new(statupGA.StatupCardView);
        ActionSystem.Instance.AddReaction(destroyCardGA);
    }
}
