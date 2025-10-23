using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private RoundView roundView;
    [SerializeField] private FloorData floorData;

    void Start()
    {
        int createCount = Mathf.Min(roundView.cardCount, floorData.FloorCards.Count);

        for (int i = 0; i < createCount; i++)
        {
            CardData cd = floorData.FloorCards[i];
            Card card = new Card(cd);

            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);

            cardView.gameObject.SetActive(true);
            roundView.CreateCards(cardView);
        }
    }
}
