using System.Collections.Generic;
using UnityEngine;

public class CardViewSetupSystem : MonoBehaviour
{
    public void CardViewSetup(FloorData floor, List<CardView> cards)
    {
        // clear existing
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            if (cards[i] != null)
                Destroy(cards[i].gameObject);
        }
        cards.Clear();

        /*if (floor == null || floor.FloorCards == null || floor.FloorCards.Count == 0)
        {
            UpdateCardPositions();
            return;
        }*/

        int createCount = floor.FloorCards.Count;

        for (int i = 0; i < createCount; i++)
        {
            CardData cd = floor.FloorCards[i];

            // EnemyCard
            if (cd is EnemyCardData enemyData)
            {
                var enemyCard = new EnemyCard(enemyData);
                var enemyCardView = EnemyCardViewCreator.Instance.CreateEnemyCardView(enemyCard, transform.position, Quaternion.identity);
                enemyCardView.gameObject.SetActive(true);
                enemyCardView.transform.SetParent(transform, worldPositionStays: true);
                cards.Add(enemyCardView);
                continue;
            }
            else if (cd is HealCardData healData)
            {
                var healCard = new HealCard(healData);
                var healCardView =  HealCardViewCreator.Instance.CreateHealCardView(healCard, transform.position, Quaternion.identity);
                healCardView.gameObject.SetActive(true);
                healCardView.transform.SetParent(transform, worldPositionStays: true);
                cards.Add(healCardView);
                continue;
            }
         
            var card = new Card(cd);
            var cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);


            // ensure active so it is visible
            cardView.gameObject.SetActive(true);

            // add to round (this parents and calls UpdateCardPositions)
            //CreateCards(cardView);
        }
    }
}