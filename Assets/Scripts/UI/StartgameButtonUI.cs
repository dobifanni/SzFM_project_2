using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartgameButtonUI : MonoBehaviour
{
    
    [SerializeField] private GameObject HeroSelectMenu;

    public void OnClick(bool ertek)
    {
        HeroSelectMenu.SetActive(ertek);
    }
}
