using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;

public class CardViewSetupSystem : Singleton<CardViewSetupSystem>
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
            ShuffleCards(floor.FloorCards);
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
            // HealCard
            else if (cd is HealCardData healData)
            {
                var healCard = new HealCard(healData);
                var healCardView = HealCardViewCreator.Instance.CreateHealCardView(healCard, transform.position, Quaternion.identity);
                healCardView.gameObject.SetActive(true);
                healCardView.transform.SetParent(transform, worldPositionStays: true);
                cards.Add(healCardView);
                continue;
            }
            // StatupCard
            else if (cd is StatupCardData statupData)
            {
                var statupCard = new StatupCard(statupData);
                var statupCardView = StatCardViewCreator.Instance.CreateStatupCardView(statupCard, transform.position, Quaternion.identity);
                statupCardView.gameObject.SetActive(true);
                statupCardView.transform.SetParent(transform, worldPositionStays: true);
                cards.Add(statupCardView);
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

    void ShuffleCards<CardData>(List<CardData> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, cards.Count);
            (cards[i], cards[RandomIndex]) = (cards[RandomIndex], cards[i]);
        }
    }
}