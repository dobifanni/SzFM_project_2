using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DealDamageGA>(DealDamagePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DealDamageGA>();
    }

    private IEnumerator DealDamagePerformer(DealDamageGA dealDamageGA)
    {
        dealDamageGA.Target.ApplyDamage(dealDamageGA.Amount);

        //animation could be here

        yield return new WaitForSeconds(0.15f);

    }
}
