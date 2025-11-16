using System.Collections;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
        ActionSystem.AttachPerformer<AttackEnemyGA>(AttackEnemyPerformer);

        // register checker that runs after DealDamageGA when attached as a PostReaction
        ActionSystem.AttachPerformer<CheckDestroyGA>(CheckDestroyPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
        ActionSystem.DetachPerformer<AttackHeroGA>();
        ActionSystem.DetachPerformer<AttackEnemyGA>();

        ActionSystem.DetachPerformer<CheckDestroyGA>();
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


        // read damage from attacker model (hero's current damage)
        int damageAmount = 0;
        if (HeroStatSystem.Instance != null)
            damageAmount = HeroStatSystem.Instance.CurrentDamage;

        // optional delay/telegraph
        yield return new WaitForSeconds(2f);

        // create DealDamage action that targets the enemy (EnemyView implements IDamageable)
        DealDamageGA dealDamageGA = new(damageAmount, target);

        // attach a CheckDestroyGA as a PostReaction so it runs AFTER DealDamageGA's performer finished
        dealDamageGA.PostReaction.Add(new CheckDestroyGA(target));

        ActionSystem.Instance.AddReaction(dealDamageGA);

        // no immediate manual DestroyCardGA here — CheckDestroyGA will enqueue DestroyCardGA if HP == 0
    }

    // Performer that runs when CheckDestroyGA is executed (registered on OnEnable)
    private IEnumerator CheckDestroyPerformer(CheckDestroyGA checkDestroyGA)
    {
        
        // small delay to allow any visual hit reaction to play; optional
        yield return null;

        var cv = checkDestroyGA.Target as EnemyCardView;
        if (cv.EnemyCard.Health <= 0)
        {
            // enqueue DestroyCardGA so removal is done through ActionSystem and RemoveCardSystem
            ActionSystem.Instance.AddReaction(new DestroyCardGA(cv));
        }

        // If other card types need different conditions, handle them here (Heal/Statup etc.)
    }
}
