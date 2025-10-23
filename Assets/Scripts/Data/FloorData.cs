using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Floor")]
public class FloorData : ScriptableObject
{
    [field: SerializeField] public List<EnemyCardData> FloorCards { get; private set; }
}
