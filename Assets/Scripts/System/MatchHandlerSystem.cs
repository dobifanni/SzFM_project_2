using UnityEngine;

public class MatchHandlerSystem : Singleton<MatchHandlerSystem>
{
    [SerializeField] private RoundView roundView;
    

    //[SerializeField] private HeroData heroData;
    public static HeroData heroData { get; set;}
    void Start()
    {
        /*if (FloorCounterSystem.FloorCount == 1)
        {
            HeroStatSystem.Instance.Setup(heroData);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundView.cards.Count == 0)
        {
            SpawnDoorSystem.Instance.SpawnDoorAtOrigin(roundView.doorCardData);
        }
        CheckSpeedSystem.Instance.CheckSpeed();
    }
}
