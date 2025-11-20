using UnityEngine;

public class DoorCardViewCreator : Singleton<DoorCardViewCreator>
{
    [SerializeField] private DoorCardView doorCardView;

    public DoorCardView CreateDoorCardView(DoorCard card, Vector3 position, Quaternion rotation)
    {
        
            var doorClone = Instantiate(doorCardView, position, rotation);
            doorClone.Setup(card);
        

        return doorClone;
    }
}
