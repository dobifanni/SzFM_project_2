using UnityEngine;

public class DestroyCardGA : GameAction
{
    public CardView CardView { get; private set; }

    public DestroyCardGA(CardView cardView)
    {
        CardView = cardView;
    }
}
