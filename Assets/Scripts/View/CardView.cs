using TMPro;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using static UnityEngine.EventSystems.EventTrigger;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text damage;
    [SerializeField] private TMP_Text speed;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;

    public EnemyCard Card { get; private set; }
    public System.Action<bool> OnSelected;
    private bool isSelected = false;
    public bool isFlipped = false;

    public void Setup(EnemyCard card)
    {
        SetSelected(false);
        Card = card;
        health.text = card.Health.ToString();
        damage.text = card.Damage.ToString();
        speed.text = card.Speed.ToString();
        imageSR.sprite = card.Image;
    }

    private void SetSelected(bool selected)
    {
        isSelected = selected;
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        transform.DORotate(new(0, isFlipped ? 180f : 0f, 0), 2.25f);
    }
}
