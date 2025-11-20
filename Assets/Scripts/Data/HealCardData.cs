using UnityEngine;

[CreateAssetMenu(menuName = "Data/HealCard")]
public class HealCardData : CardData
{
    [field: SerializeField] public int Healing  { get; private set; }
}