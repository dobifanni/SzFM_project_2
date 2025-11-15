using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FloorSelectSystem : Singleton<FloorSelectSystem>
{

    [SerializeField] private FloorData regularFloor;
    [SerializeField] private FloorData encounterFloor;
    [SerializeField] private FloorData specialFloor;
    [SerializeField] private CardViewSetupSystem cardViewSetupSystem;

    void Start()
    {
        regularFloor = Resources.Load<FloorData>("Data/Floor/Floor" + FloorCounterSystem.FloorCount.ToString());
        //Loads random Encounter floors' data, it's randomized, change numbers based on number of encounter floors created
        encounterFloor = Resources.Load<FloorData>("Data/Floor/EncounterFloor" + UnityEngine.Random.Range(1, 2).ToString());
        //Loads non-random Special floors' data, it's randomized, change numbers based on number of encounter floors created
        specialFloor = Resources.Load<FloorData>("Data/Floor/SpecialFloor" + UnityEngine.Random.Range(1, 2).ToString());
        FloorDataUpdate();
        
    }
    
public void FloorDataUpdate()
        {
            if (FloorCounterSystem.FloorCount < 2)
            {
                //Ensures game doesn't start with an encounter
                RoundView.lastFloorWasEncounter = true;
            }
            //Change this number if more floors are added, also change it in RoundView
            if (FloorCounterSystem.FloorCount < 6)
            {
                if (RoundView.rnd > 0.8f && RoundView.lastFloorWasEncounter == false && FloorCounterSystem.FloorCount % 3 != 0)
                {
                    //This is for the random big enemy floors
                    cardViewSetupSystem.CardViewSetup(encounterFloor, RoundView.cards);
                    //Uncomment next line if we want encounters to replace floors, not be additional ones
                    //FloorCounterSystem.FloorNumberUp();
                    RoundView.lastFloorWasEncounter = true;
                }
                //Special floors appear every 3 floors, this is arbitrary, feel free to change
                else if (FloorCounterSystem.FloorCount % 3 == 0 && RoundView.lastFloorWasSpecial == false)
                {
                    //This is for the heal/loot floors at fixed floors
                    cardViewSetupSystem.CardViewSetup(specialFloor, RoundView.cards);
                    RoundView.lastFloorWasSpecial = true;
                }
                else
                {
                    //This is just regular floor progression
                    cardViewSetupSystem.CardViewSetup(regularFloor, RoundView.cards);
                    FloorCounterSystem.FloorNumberUp();
                    RoundView.lastFloorWasSpecial = false;
                    RoundView.lastFloorWasEncounter = false;
                }
            }
        }
    }