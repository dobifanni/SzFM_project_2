using UnityEngine;

[CreateAssetMenu(menuName = "Data/DoorCard")]
public class DoorCardData : CardData
{
    [field: SerializeField] public string Description { get; private set; }
}
