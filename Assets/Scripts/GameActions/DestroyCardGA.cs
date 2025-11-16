using UnityEngine;

public class DestroyCardGA : GameAction
{
    public CardView Target { get; private set; }

    public DestroyCardGA(CardView target)
    {
        Target = target;
    }
}
