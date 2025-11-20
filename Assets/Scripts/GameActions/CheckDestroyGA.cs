using UnityEngine;

public class CheckDestroyGA : GameAction
{
    public CardView Target { get; }

    public CheckDestroyGA(CardView target)
    {
        Target = target;
    }
}