using System.Collections;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
        ActionSystem.AttachPerformer<AttackEnemyGA>(AttackEnemyPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
        ActionSystem.DetachPerformer<AttackHeroGA>();
        ActionSystem.DetachPerformer<AttackEnemyGA>();
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

        AttackEnemyGA attackEnemyGA = new(attacker);
        ActionSystem.Instance.AddReaction(attackEnemyGA);


        yield return null;

        Debug.Log("Enemy Turn Over");
        
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

    private IEnumerator AttackEnemyPerformer(AttackEnemyGA attackenemyGA)
    {
        EnemyCardView target = attackenemyGA.Target;


        // read damage from attacker model
        int damageAmount = 0;
        if (target.EnemyCard != null)
            damageAmount = HeroStatSystem.Instance.CurrentDamage;

        // optional delay/telegraph
        yield return new WaitForSeconds(2f);

        // create DealDamage action that targets the enemy (EnemyView implements IDamageable)
        DealDamageGA dealDamageGA = new(damageAmount, target);
        ActionSystem.Instance.AddReaction(dealDamageGA);

        yield return new WaitForSeconds(0.15f);

        if (target.EnemyCard.Health == 0)
        {
            DestroyCardGA destroyCardGA = new(target);
            ActionSystem.Instance.AddReaction(destroyCardGA);
        }
        
    }
}
