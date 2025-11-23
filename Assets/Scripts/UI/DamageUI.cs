using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text damage;

    public void UpdateDamageText(int currentDamage)
    {
        damage.text = currentDamage.ToString();
    }
}
