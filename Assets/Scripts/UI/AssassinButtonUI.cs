using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssassinButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI classNameText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] HeroData assassin;
    
    void Start()
    {
        classNameText.text = "Assassin";
        speedText.text = assassin.Speed.ToString();
        damageText.text = assassin.Damage.ToString();
        healthText.text = assassin.Health.ToString();
        
        FloorCounterSystem.FloorCount = 1;
    }
    
    public void Palyatoltes(string sceneNev)
    {
        SceneManager.LoadScene(sceneNev);
        MatchSetupSystem.heroData = assassin;
    }
}
