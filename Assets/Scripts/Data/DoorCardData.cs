using UnityEngine;

[CreateAssetMenu(menuName = "Data/DoorCard")]
public class DoorCardData : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
}
