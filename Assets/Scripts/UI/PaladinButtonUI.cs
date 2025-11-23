using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaladinButtonUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI classNameText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] HeroData paladin;
    
    void Start()
    {
        classNameText.text = "Paladin";
        speedText.text = paladin.Speed.ToString();
        damageText.text = paladin.Damage.ToString();
        healthText.text = paladin.Health.ToString();

        FloorCounterSystem.FloorCount = 1;
    }
    
    public void Palyatoltes(string sceneNev)
    {
        HeroStatSystem.Instance.Setup(paladin);
        SceneManager.LoadScene(sceneNev);
    }
}
