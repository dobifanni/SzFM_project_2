using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    //[SerializeField] private HeroData heroData;
    public static HeroData heroData { get; set;}
    void Start()
    {
        HeroStatSystem.Instance.Setup(heroData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
