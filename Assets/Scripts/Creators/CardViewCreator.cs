using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private EnemyCardView enemyCardViewPrefab;
    [SerializeField] private DoorCardView doorCardViewPrefab;
    [SerializeField] private HealCardView healCardViewPrefab;
    [SerializeField] private StatupCardView statupCardViewPrefab;

    public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
    {
        CardView prefab = card switch
        {
            EnemyCard => enemyCardViewPrefab,
            DoorCard => doorCardViewPrefab,
            HealCard => healCardViewPrefab,
            StatupCard => statupCardViewPrefab,
            _ => cardViewPrefab
        };

        CardView view;
        view = Instantiate(prefab, position, rotation);
        view.Setup(card);
        
        return view;
    }
}
