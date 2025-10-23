using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyCard")]
public class EnemyCardData : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
}
