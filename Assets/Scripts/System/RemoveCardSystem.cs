using UnityEngine;

public class RemoveCardSystem : Singleton<RemoveCardSystem>
{
    public bool isMoving = false;

    [SerializeField] private RoundView RoundView;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DestroyCardGA>(RemoveAndShiftPermorfer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DestroyCardGA>();
    }


    System.Collections.IEnumerator RemoveAndShiftPermorfer(DestroyCardGA destroyCardGA)
    {
        isMoving = true;

        
            // remove and destroy the view object

            

            RoundView.cards.Remove(destroyCardGA.Target);
            Destroy(destroyCardGA.Target.gameObject);
        

        // shift offset by the fraction based on the number of cards before removal
        RoundView.circleTOffset += 1f / Mathf.Max(1, (RoundView.cards.Count + 1));

        yield return null;

        isMoving = false;

        if (RoundView.cards.Count > 0)
        {
            if (RoundView.cards[0].isFlipped) RoundView.cards[0].Flip();
            if (RoundView.cards[^1].isFlipped) RoundView.cards[^1].Flip();
        }
    }
}
