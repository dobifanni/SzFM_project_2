using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public void OnClick()
    {
        PauseMenu.SetActive(true);
    }
}
