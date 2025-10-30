using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private EnemyCardView enemyCardViewPrefab;
    [SerializeField] private DoorCardView doorCardViewPrefab;

    public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
    {
        CardView prefab = card switch
        {
            EnemyCard => enemyCardViewPrefab,
            DoorCard => doorCardViewPrefab,
            _ => cardViewPrefab
        };

        CardView view;
        view = Instantiate(prefab, position, rotation);
        view.Setup(card);
        
        return view;
    }
}
