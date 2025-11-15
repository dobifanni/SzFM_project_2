using UnityEngine;

public class RemoveCardSystem : Singleton<RemoveCardSystem>
{
    public bool isMoving = false;

    [SerializeField] private RoundView RoundView;

    public void RemoveFrontCard(GameObject clickedCard)
    {
        if (isMoving) return;

        CardView cv = RoundView.cards.Find(c => c.gameObject == clickedCard);
        if (cv == null) return;

        EnemyTurnGA enemyTurnGA = new();
        ActionSystem.Instance.Perform(enemyTurnGA);

        StartCoroutine(RemoveAndShift(cv));
    }

    System.Collections.IEnumerator RemoveAndShift(CardView clickedCard)
    {
        isMoving = true;

        if (clickedCard != null)
        {
            // remove and destroy the view object

            

            RoundView.cards.Remove(clickedCard);
            Destroy(clickedCard.gameObject);
        }

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
