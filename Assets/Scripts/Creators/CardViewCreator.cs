using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewprefab;

    public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
    {
        CardView cardView;

        if (cardViewprefab != null)
        {
            cardView = Instantiate(cardViewprefab, position, rotation);
        }
        else
        {
            Debug.LogWarning("CardViewCreator: cardViewprefab is not assigned in the inspector. Creating fallback CardView GameObject.");
            GameObject go = new GameObject("CardView_Fallback");
            go.transform.position = position;
            go.transform.rotation = rotation;
            cardView = go.AddComponent<CardView>();
        }

        if (cardView != null)
            cardView.Setup(card);
        else
            Debug.LogError("CardViewCreator: Failed to create CardView instance.");

        return cardView;
    }
}
