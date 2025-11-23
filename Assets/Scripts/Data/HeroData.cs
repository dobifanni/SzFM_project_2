using UnityEngine;

[CreateAssetMenu(menuName = "Data/HeroData")]
public class HeroData : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Speed{ get; private set; }
}
