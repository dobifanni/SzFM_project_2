using TMPro;
using UnityEngine;

public class EnemyCardView : CardView
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
}
