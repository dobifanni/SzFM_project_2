using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private RoundView roundView;
    [SerializeField] private CardData cardData;

    void Start()
    {
        // create up to 9 cards (or roundView.cardCount if smaller)
        int desiredCount = Mathf.Min(roundView.cardCount, 9);

        for (int i = 0; i < desiredCount; i++)
        {
            Card card = new(cardData);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position + Vector3.up * 0.01f * i, Quaternion.identity);

            // ensure the created view is active and add it to the round
            cardView.gameObject.SetActive(true);
            roundView.CreateCards(cardView);
        }
    }
}
