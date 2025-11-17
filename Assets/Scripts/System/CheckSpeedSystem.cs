using UnityEngine;

public class CheckSpeedSystem : Singleton<CheckSpeedSystem>
{
    public void CheckSpeed()
    {
        for(int i = 0; i < RoundView.cards.Count; i++)
        {

            int speed = HeroStatSystem.Instance.CurrentSpeed; //replace with player's speed

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