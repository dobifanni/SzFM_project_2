using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EnemySystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
        ActionSystem.AttachPerformer<AttackEnemyGA>(AttackEnemyPerformer);
        ActionSystem.AttachPerformer<CheckDestroyGA>(CheckDestroyPerformer);
        ActionSystem.AttachPerformer<SpeedCheckGA>(SpeedCheckPerformer);
        ActionSystem.AttachPerformer<AttackHeroIfAliveGA>(AttackHeroIfAlivePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
        ActionSystem.DetachPerformer<AttackHeroGA>();
        ActionSystem.DetachPerformer<AttackEnemyGA>();
        ActionSystem.DetachPerformer<CheckDestroyGA>();
        ActionSystem.DetachPerformer<SpeedCheckGA>();
        ActionSystem.DetachPerformer<AttackHeroIfAliveGA>();
    }

    public void getClickedCard(GameObject clickedCard)
    {
        CardView cv = RoundView.cards.Find(c => c.gameObject == clickedCard);
    }

    private IEnumerator EnemyTurnPerformer(EnemyTurnGA enemyTurnGA)
    {
        var enemy = enemyTurnGA?.Target;
        if (enemy == null || HeroStatSystem.Instance == null)
            yield break;

        // Enqueue speed check – this will decide attack order
        ActionSystem.Instance.AddReaction(new SpeedCheckGA(enemy, HeroStatSystem.Instance));
        yield return null;
    }

    private IEnumerator SpeedCheckPerformer(SpeedCheckGA speedCheckGA)
    {
        var enemy = speedCheckGA.Enemy;
        var hero = speedCheckGA.Hero;
        if (enemy == null || hero == null || enemy.EnemyCard == null)
            yield break;

        int heroSpeed = hero.CurrentSpeed;
        int enemySpeed = enemy.EnemyCard.Speed;

        if (heroSpeed >= enemySpeed)
        {
            // Hero attacks first; enemy only retaliates if still alive
            ActionSystem.Instance.AddReaction(new AttackEnemyGA(enemy, true));
        }
        else
        {
            // Enemy attacks first; hero always gets a counter-attack (if still alive logic could be added similarly)
            ActionSystem.Instance.AddReaction(new AttackHeroGA(enemy));
            ActionSystem.Instance.AddReaction(new AttackEnemyGA(enemy, false));
        }

        yield return null;
    }

    private IEnumerator AttackHeroPerformer(AttackHeroGA attackHeroGA)
    {
        EnemyCardView attacker = attackHeroGA.Attacker;
        int damageAmount = attacker?.EnemyCard != null ? attacker.EnemyCard.Damage : 0;

        // optional delay/telegraph
        attacker.transform.DOShakeScale(0.4f, new Vector3(0.5f, 0.5f, 0f), 5, 0f);
        yield return new WaitForSeconds(0.5f);

        // create DealDamage action that targets the hero (HeroStatSystem implements IDamageable)
        DealDamageGA dealDamageGA = new(damageAmount, HeroStatSystem.Instance);
        ActionSystem.Instance.AddReaction(dealDamageGA);
    }

    private IEnumerator AttackEnemyPerformer(AttackEnemyGA attackenemyGA)
    {
        EnemyCardView target = attackenemyGA.Target;
        int damageAmount = HeroStatSystem.Instance != null ? HeroStatSystem.Instance.CurrentDamage : 0;

        // optional delay/telegraph
        target.transform.DOShakePosition(0.4f);
        yield return new WaitForSeconds(0.5f);

        // create DealDamage action that targets the enemy (EnemyView implements IDamageable)
        DealDamageGA dealDamageGA = new(damageAmount, target);
        // Always check for destruction
        dealDamageGA.PostReaction.Add(new CheckDestroyGA(target));

        // If hero acted first, schedule conditional enemy retaliation after damage & destroy check
        if (attackenemyGA.HeroActsFirst)
        {
            dealDamageGA.PostReaction.Add(new AttackHeroIfAliveGA(target));
        }

        ActionSystem.Instance.AddReaction(dealDamageGA);
    }

    private IEnumerator AttackHeroIfAlivePerformer(AttackHeroIfAliveGA ga)
    {
        var enemy = ga.Enemy;
        if (enemy != null && enemy.EnemyCard != null && enemy.EnemyCard.Health > 0)
        {
            ActionSystem.Instance.AddReaction(new AttackHeroGA(enemy));
        }
        yield return null;
    }

    // Performer that runs when CheckDestroyGA is executed (registered on OnEnable)
    private IEnumerator CheckDestroyPerformer(CheckDestroyGA checkDestroyGA)
    {
        // small delay to allow any visual hit reaction to play; optional
        yield return null;

        var cv = checkDestroyGA.Target as EnemyCardView;
        if (cv?.EnemyCard != null && cv.EnemyCard.Health <= 0)
        {
            // enqueue DestroyCardGA so removal is done through ActionSystem and RemoveCardSystem
            ActionSystem.Instance.AddReaction(new DestroyCardGA(cv));
        }
    }
}
