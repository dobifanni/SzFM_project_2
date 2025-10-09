using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public void OnClick()
    {
        PauseMenu.SetActive(false);
    }
}
