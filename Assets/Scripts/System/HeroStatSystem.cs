using UnityEngine;

public class HeroStatSystem : Singleton<HeroStatSystem>
{
    [SerializeField]private GameObject HeroStats;
   

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int CurrentDamage{ get; private set; }
    public int CurrentSpeed { get; private set; }


    public void Setup(HeroData heroData)
    {
        MaxHealth = CurrentHealth = heroData.Health;
        CurrentDamage = heroData.Damage;
        CurrentSpeed = heroData.Speed;
        HeroStats.GetComponentInChildren<HealthUI>().UpdateHPText(heroData.Health);
        HeroStats.GetComponentInChildren<DamageUI>().UpdateDamageText(heroData.Damage);
        HeroStats.GetComponentInChildren<SpeedUI>().UpdateSpeedText(heroData.Speed);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
