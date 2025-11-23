using UnityEngine;

public class SpeedCheckGA : GameAction
{
    public EnemyCardView Enemy { get; }
    public HeroStatSystem Hero { get; }

    public SpeedCheckGA(EnemyCardView enemy, HeroStatSystem hero)
    {
        Enemy = enemy;
        Hero = hero;
    }
}
