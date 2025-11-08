using UnityEngine;

public class SpawnDoorSystem : Singleton<SpawnDoorSystem>
{
    public static void SpawnDoorAtOrigin(DoorCardData doorCardData)
    {
        if (RoundView.doorSpawned) return;
        DoorCard door = new DoorCard(doorCardData);
        DoorCardView doorView = DoorCardViewCreator.Instance.CreateDoorCardView(door, Vector3.zero, Quaternion.identity);

        doorView.gameObject.SetActive(true);
        // stays at world (0,0,0) as requested
        RoundView.doorSpawned = true;
    }
}