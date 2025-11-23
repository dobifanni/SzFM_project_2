using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyCard")]
public class EnemyCardData : CardData
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
}
