using UnityEngine;

public class HeroStatSystem : Singleton<HeroStatSystem>, IDamageable
{
    [SerializeField] private GameObject HeroStats;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int CurrentDamage { get; private set; }
    public int CurrentSpeed { get; private set; }

    public void Setup(HeroData heroData)
    {
        MaxHealth = CurrentHealth = heroData.Health;
        CurrentDamage = heroData.Damage;
        CurrentSpeed = heroData.Speed;
        CallHPuiUpdate(CurrentHealth);
        CallDamageuiUpdate(CurrentDamage);
        CallSpeeduiUpdate(CurrentSpeed);
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

    // IDamageable implementation: reduce hero health and update UI
    public void ApplyDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - Mathf.Max(0, amount));
        CallHPuiUpdate(CurrentHealth);

        // optional: death check, animations, etc.
    }
}
