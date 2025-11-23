using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hp;

    public void UpdateHPText(int currentHP, int maxHP)
    {
        hp.text = $"{currentHP}/{maxHP}";
    }
}
