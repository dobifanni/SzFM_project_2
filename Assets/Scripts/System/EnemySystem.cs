using System.Collections;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
        ActionSystem.DetachPerformer<AttackHeroGA>();
    }

    public void getClickedCard(GameObject clickedCard)
    {
        CardView cv = RoundView.cards.Find(c => c.gameObject == clickedCard);
    }

    private IEnumerator EnemyTurnPerformer(EnemyTurnGA enemyTurnGA)
    {
        Debug.Log("Enemy Turn");

        var attacker = enemyTurnGA?.Target;
            
        AttackHeroGA attackHeroGA = new(attacker);
        ActionSystem.Instance.AddReaction(attackHeroGA);
        

        Debug.Log("Enemy Turn Over");
        yield return null;
    }

    private IEnumerator AttackHeroPerformer(AttackHeroGA attackHeroGA)
    {
        EnemyCardView attacker = attackHeroGA.Attacker;
        

        // read damage from attacker model
        int damageAmount = 0;
        if (attacker.EnemyCard != null)
            damageAmount = attacker.EnemyCard.Damage;

        // optional delay/telegraph
        yield return new WaitForSeconds(2f);

        // create DealDamage action that targets the hero (HeroStatSystem implements IDamageable)
        DealDamageGA dealDamageGA = new(damageAmount, HeroStatSystem.Instance);
        ActionSystem.Instance.AddReaction(dealDamageGA);
    }
}
