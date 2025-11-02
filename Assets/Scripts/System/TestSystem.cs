/*using System.Collections.Generic;
using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private RoundView roundView;
    [SerializeField] private FloorData floorData;
    [SerializeField] private DoorCardData doorCardData;

    private readonly List<CardView> createdCardViews = new List<CardView>();
    private bool doorSpawned;

    void Start()
    {
        int createCount = Mathf.Min(roundView.cardCount, floorData.FloorCards.Count);

        for (int i = 0; i < createCount; i++)
        {
            CardData cd = floorData.FloorCards[i];
            Card card = new Card(cd);

            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);
            if (cardView == null) continue;

            cardView.gameObject.SetActive(true);
            roundView.CreateCards(cardView);

            createdCardViews.Add(cardView);
        }
    }


    void Update()
    {
        if (doorSpawned) return;

        // remove destroyed/null references
        createdCardViews.RemoveAll(cv => cv == null);

        // when all enemy card views are gone, spawn door at world origin
        if (createdCardViews.Count == 0)
        {
            SpawnDoorAtOrigin();
            doorSpawned = true;
        }
    }

    private void SpawnDoorAtOrigin()
    {

        DoorCard door = new DoorCard(doorCardData);
        DoorCardView doorView = DoorCardViewCreator.Instance.CreateDoorCardView(door, Vector3.zero, Quaternion.identity);

        doorView.gameObject.SetActive(true);
        // stays at world (0,0,0) as requested

    }

}*/