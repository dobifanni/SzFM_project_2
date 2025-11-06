using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    void Start()
    {
        HeroStatSystem.Instance.Setup(heroData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
