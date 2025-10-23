using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoorCardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;

    public DoorCard Card { get; private set; }

    public void Setup(DoorCard card)
    {
        Card = card;
        imageSR.sprite = card.Image;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("DoorCardView: OnPointerClick");
        ReloadCombatScene();
    }

    // Fallback for regular physics clicks (requires collider on the GameObject)
    void OnMouseDown()
    {
        Debug.Log("Kattintva");
        ReloadCombatScene();
    }

    // Public so it can be invoked from other scripts/tests if needed
    public void ReloadCombatScene()
    {
        SceneManager.LoadScene("CombatScene");
    }
}
