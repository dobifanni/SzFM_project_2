using UnityEngine;

public class EnemyCardViewCreator : Singleton<EnemyCardViewCreator>
{
    [SerializeField] private EnemyCardView enemyCardView;

    public EnemyCardView CreateEnemyCardView(EnemyCard card, Vector3 position, Quaternion rotation)
    {

        var enemyClone = Instantiate(enemyCardView, position, rotation);
        enemyClone.Setup(card);


        return enemyClone;
    }
}
