using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatupCard")]
public class StatupCardData : CardData
{
    [field: SerializeField] public Stats StatType { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}
