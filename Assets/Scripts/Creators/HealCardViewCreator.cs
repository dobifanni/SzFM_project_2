using UnityEngine;

public class HealCardViewCreator : Singleton<HealCardViewCreator>
{
    [SerializeField] private HealCardView healCardView;

    public HealCardView CreateHealCardView(HealCard card, Vector3 position, Quaternion rotation)
    {

        var healClone = Instantiate(healCardView, position, rotation);
        healClone.Setup(card);


        return healClone;
    }
}