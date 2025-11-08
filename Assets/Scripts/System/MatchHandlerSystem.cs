using UnityEngine;

public class MatchHandlerSystem : Singleton<MatchHandlerSystem>
{
    [SerializeField] private RoundView roundView;
    [SerializeField] private SpawnDoorSystem SpawnDoorSystem;

    //[SerializeField] private HeroData heroData;
    public static HeroData heroData { get; set;}
    void Start()
    {
        HeroStatSystem.Instance.Setup(heroData);
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundView.cards.Count == 0)
        {
            SpawnDoorSystem.SpawnDoorAtOrigin(roundView.doorCardData);
        }
        CheckSpeedSystem.CheckSpeed();
    }
}
