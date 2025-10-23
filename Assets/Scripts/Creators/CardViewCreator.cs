using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewprefab;

    public CardView CreateCardView(EnemyCard card, Vector3 position, Quaternion rotation)
    {
        CardView cardView;
        cardView = Instantiate(cardViewprefab, position, rotation);
        cardView.Setup(card);
        
        return cardView;
    }
}
