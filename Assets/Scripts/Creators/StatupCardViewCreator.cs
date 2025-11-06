using UnityEngine;

public class StatCardViewCreator : Singleton<StatCardViewCreator>
{
    [SerializeField] private StatupCardView statupCardView;

    public StatupCardView CreateStatupCardView(StatupCard card, Vector3 position, Quaternion rotation)
    {
        var statupClone = Instantiate(statupCardView, position, rotation);
        statupClone.Setup(card);

        return statupClone;
    }
}
