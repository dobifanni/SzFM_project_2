using TMPro;
using UnityEngine;
using UnityEngine.UI;

// EnemyCardView extends CardView
public class EnemyCardView : CardView, IDamageable
{
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text damage;
    [SerializeField] private TMP_Text speed;
    [SerializeField] public  Image healthBar;
    private int maxHealth;

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
        healthBar.fillAmount = 1;
        maxHealth = card.Health;
    }

    // IDamageable implementation: update model + UI
    public void ApplyDamage(int amount)
    {
        if (EnemyCard == null) return;

        EnemyCard.ApplyDamage(amount);
        if (health != null)
        {
            health.text = EnemyCard.Health.ToString();
            if (EnemyCard.Health > 0)
            {
                healthBar.fillAmount = (float)EnemyCard.Health / maxHealth;
            }
        }

        // optional: play hit animation/tween here
    }
}
