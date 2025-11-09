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
        CallHPuiUpdate(heroData.Health);
        CallDamageuiUpdate(heroData.Damage);
        CallSpeeduiUpdate(heroData.Speed);
    }
    public void CallHPuiUpdate(int amount)
    {
        HeroStats.GetComponentInChildren<HealthUI>().UpdateHPText(amount);
    }

    public void CallDamageuiUpdate(int amount)
    {
        HeroStats.GetComponentInChildren<DamageUI>().UpdateDamageText(amount);
    }

    public void CallSpeeduiUpdate(int amount)
    {
        HeroStats.GetComponentInChildren<SpeedUI>().UpdateSpeedText(amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
