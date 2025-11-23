using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FloorSelectSystem : Singleton<FloorSelectSystem>
{
    [SerializeField] private FloorData regularFloor;
    [SerializeField] private FloorData specialHealFloor;
    [SerializeField] private FloorData specialStatupFloor;
    [SerializeField] private CardViewSetupSystem cardViewSetupSystem;

    private static bool healSpawnedOnce;
    private static bool statupSpawnedOnce;

    void Start()
    {
        if (FloorCounterSystem.FloorCount <= 1)
        {
            healSpawnedOnce = false;
            statupSpawnedOnce = false;
            RoundView.lastFloorWasSpecial = false;
        }

        regularFloor      = Resources.Load<FloorData>("Data/Floor/Floor" + FloorCounterSystem.FloorCount.ToString());
        specialHealFloor  = Resources.Load<FloorData>("Data/Floor/SpecialFloorHeal");
        specialStatupFloor= Resources.Load<FloorData>("Data/Floor/SpecialFloorStatup");

        FloorDataUpdate();
    }

    public void FloorDataUpdate()
    {
        // first regular floor should not be a special
        if (FloorCounterSystem.FloorCount < 2)
        {
            RoundView.lastFloorWasSpecial = true;
        }

        if (FloorCounterSystem.FloorCount < 6)
        {
            bool lastWasSpecial = RoundView.lastFloorWasSpecial;

            if (!lastWasSpecial)
            {
                float rollHeal = Random.value; // 30%
                float rollStat = Random.value; // 30%

                bool canHeal = !healSpawnedOnce   && rollHeal < 0.4f;
                bool canStat = !statupSpawnedOnce && rollStat < 0.4f;

                if (canHeal || canStat)
                {
                    bool chooseHeal = canHeal && canStat ? Random.value < 0.5f : canHeal;

                    if (chooseHeal)
                    {
                        cardViewSetupSystem.CardViewSetup(specialHealFloor, RoundView.cards);
                        healSpawnedOnce = true;
                        RoundView.lastFloorWasSpecial = true;
                        return;
                    }
                    else
                    {
                        cardViewSetupSystem.CardViewSetup(specialStatupFloor, RoundView.cards);
                        statupSpawnedOnce = true;
                        RoundView.lastFloorWasSpecial = true;
                        return;
                    }
                }
            }

            // Regular floor (increments floor count)
            regularFloor = Resources.Load<FloorData>("Data/Floor/Floor" + FloorCounterSystem.FloorCount.ToString());
            cardViewSetupSystem.CardViewSetup(regularFloor, RoundView.cards);
            FloorCounterSystem.FloorNumberUp();
            RoundView.lastFloorWasSpecial = false;
        }
    }
}