using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using static UnityEngine.EventSystems.EventTrigger;

public class CardView : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer imageSR;
    [SerializeField] protected GameObject wrapper;

    public Card Card { get; private set; }
    public System.Action<bool> OnSelected;
    protected bool isSelected = false;
    public bool isFlipped = false;

    public void Setup(Card card)
    {
        Card = card;
        imageSR.sprite = card.Image;
    }

    protected void SetSelected(bool selected)
    {
        isSelected = selected;
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        transform.DORotate(new(0, isFlipped ? 180f : 0f, 0), 0.55f);
    }
}
