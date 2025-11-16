using UnityEngine;

public class DealDamageGA : GameAction
{
    public int Amount { get; set; }
    public IDamageable Target { get; set; }

    public DealDamageGA(int amount, IDamageable target)
    {
        Amount = amount;
        Target = target;
    }
}
