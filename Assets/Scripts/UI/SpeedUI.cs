using TMPro;
using UnityEngine;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] private TMP_Text speed;

    public void UpdateSpeedText(int currentSpeed)
    {
        speed.text = currentSpeed.ToString();
    }
}
