using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoorCardView : CardView, IPointerClickHandler
{
    [SerializeField] private TMP_Text description;

    public DoorCard DoorCard { get; private set; }

    public void Setup(DoorCard card)
    {
        base.Setup(card);

        DoorCard = card;
        description.text = card.Description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ReloadCombatScene();
    }

    /*// Fallback for regular physics clicks (requires collider on the GameObject)
    void OnMouseDown()
    {
        Debug.Log("Kattintva");
        ReloadCombatScene();
    }*/

    // Public so it can be invoked from other scripts/tests if needed
    public void ReloadCombatScene()
    {
        SceneManager.LoadScene("CombatScene");
    }
}
