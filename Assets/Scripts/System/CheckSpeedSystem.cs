using UnityEngine;

public class CheckSpeedSystem : MonoBehaviour
{
    public static void CheckSpeed()
    {
        for(int i = 0; i < RoundView.cards.Count; i++)
        {

            int speed = 2; //replace with player's speed

            if (RoundView.cards[i] is EnemyCardView enemyCardView)
            {
                if (enemyCardView.EnemyCard.Speed < speed)
                {
                    enemyCardView.speedUp.enabled = false;
                    enemyCardView.speedDown.enabled = true;
                }
                else
                {
                    enemyCardView.speedDown.enabled = false;
                    enemyCardView.speedUp.enabled = true;
                }
            }
        }
    }
}