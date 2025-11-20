using TMPro;
using UnityEngine;

// EnemyCardView extends CardView
public class EnemyCardView : CardView, IDamageable
{
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text damage;
    [SerializeField] private TMP_Text speed;

    [SerializeField] public SpriteRenderer speedUp;
    [SerializeField] public SpriteRenderer speedDown;

    public EnemyCard EnemyCard { get; private set; }

    public void Setup(EnemyCard card)
    {
        SetSelected(false);

        base.Setup(card);

        EnemyCard = card;
        health.text = card.Health.ToString();
        damage.text = card.Damage.ToString();
        speed.text = card.Speed.ToString();
    }

    // IDamageable implementation: update model + UI
    public void ApplyDamage(int amount)
    {
        if (EnemyCard == null) return;

        EnemyCard.ApplyDamage(amount);
        if (health != null)
            health.text = EnemyCard.Health.ToString();

        // optional: play hit animation/tween here
    }
}
