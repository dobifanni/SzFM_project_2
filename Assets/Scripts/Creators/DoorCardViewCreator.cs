using UnityEngine;

public class DoorCardViewCreator : Singleton<DoorCardViewCreator>
{
    [SerializeField] private DoorCardView doorCardView;

    public DoorCardView CreateDoorCardView(DoorCard card, Vector3 position, Quaternion rotation)
    {
        DoorCardView doorcardView;
        doorcardView = Instantiate(doorCardView, position, rotation);
        doorcardView.Setup(card);

        return doorcardView;
    }
}
