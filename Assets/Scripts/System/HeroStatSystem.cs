using UnityEngine;

public class HeroStatSystem : PersistentSingleton<HeroStatSystem>, IDamageable
{
    private GameObject HeroStats;

    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int CurrentDamage { get; set; }
    public int CurrentSpeed { get; set; }
    public bool initialized = false;
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    public void Setup(HeroData heroData)
    {
        if (initialized) return;
        MaxHealth = CurrentHealth = heroData.Health;
        CurrentDamage = heroData.Damage;
        CurrentSpeed = heroData.Speed;
        
        initialized = true;
    }

    public void callUI()
    {
        CallHPuiUpdate(CurrentHealth);
        CallDamageuiUpdate(CurrentDamage);
        CallSpeeduiUpdate(CurrentSpeed);
    }
    
    public void CallHPuiUpdate(int currentHP)
    {
        HeroStats.GetComponentInChildren<HealthUI>().UpdateHPText(currentHP, MaxHealth);
    }

    public void SetupUI(GameObject uiRoot)
    {
        HeroStats = uiRoot;
    }

    public void CallDamageuiUpdate(int amount)
    {
        HeroStats.GetComponentInChildren<DamageUI>().UpdateDamageText(amount);
    }

    public void CallSpeeduiUpdate(int amount)
    {
        HeroStats.GetComponentInChildren<SpeedUI>().UpdateSpeedText(amount);
    }

    // IDamageable implementation: reduce hero health and update UI
    public void ApplyDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - Mathf.Max(0, amount));
        CallHPuiUpdate(CurrentHealth);

        // optional: death check, animations, etc.
    }
}
