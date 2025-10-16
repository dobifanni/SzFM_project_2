using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class RoundView : MonoBehaviour
{
    [Header("Spline alapú kártyakör")]
    public SplineContainer circleSpline;
    public GameObject cardPrefab;
    public int cardCount = 10;
    public static Camera mainCamera;
    public float frontZOffset = 0.2f;
    public float circleTOffset = 0f;

    private List<GameObject> cards = new List<GameObject>();
    private bool isMoving = false;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        if (!mainCamera) mainCamera = Camera.main;
        CreateCards();
        UpdateCardPositions();
    }

    private void Update()
    {
        HandleRaycastInput();
    }

    void HandleRaycastInput()
    {
        if (isMoving || cards.Count == 0) return;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePos);

            RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
            if (hits.Length == 0) return;

            List<RaycastHit> validHits = new List<RaycastHit>();
            foreach (var hit in hits)
            {
                if (cards.Contains(hit.collider.gameObject))
                    validHits.Add(hit);
            }

            if (validHits.Count == 0) return;

            validHits.Sort((a, b) => a.distance.CompareTo(b.distance));

            int activeCount = Mathf.Min(2, validHits.Count);

            for (int i = 0; i < activeCount; i++)
            {
                GameObject hitCard = validHits[i].collider.gameObject;
                Debug.Log($"Kattintott kártya: {hitCard.name}");
                RemoveFrontCard(hitCard);
            }
        }
    }

    void CreateCards()
    {
        for (int i = 0; i < cardCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform);
            cards.Add(card);
        }
    }

    void UpdateCardPositions(bool animate = false)
    {
        if (!circleSpline || cards.Count == 0) return;

        for (int i = 0; i < cards.Count; i++)
        {
            float t = Mathf.Repeat(circleTOffset + (float)i / cards.Count, 1f);
            Vector3 splinePos = circleSpline.EvaluatePosition(t);

            Vector3 cameraToSpline = (splinePos - mainCamera.transform.position).normalized;
            bool isFront = Vector3.Dot(mainCamera.transform.forward, cameraToSpline) > 0.7f;
            if (isFront)
                splinePos += mainCamera.transform.forward * frontZOffset;

            cards[i].transform.position = splinePos;
            cards[i].transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
        }
    }

    public void RemoveFrontCard(GameObject clickedCard)
    {
        if (isMoving) return;
        StartCoroutine(RemoveAndShift(clickedCard));
    }

    System.Collections.IEnumerator RemoveAndShift(GameObject clickedCard)
    {
        isMoving = true;

        cards.Remove(clickedCard);
        Destroy(clickedCard);

        circleTOffset += 1f / cardCount;

        yield return null;
        UpdateCardPositions();

        isMoving = false;
    }
}
