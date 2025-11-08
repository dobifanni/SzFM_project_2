using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class RoundView : MonoBehaviour
{
    public SplineContainer circleSpline;
    public GameObject cardPrefab;
    public int cardCount = 10;
    [SerializeField] private DoorCardData doorCardData;

    [SerializeField] private FloorData floorData; // assign in inspector or call PopulateFromFloor manually

    public static Camera mainCamera;
    public float frontZOffset = 0.2f;
    public float circleTOffset = 0f;

    public float fallbackRadius = 2f;

    // store CardView instances instead of raw GameObjects
    private List<CardView> cards = new List<CardView>();
    private bool isMoving = false;
    private bool doorSpawned = false;
    
    [SerializeField] private CardViewSetupSystem cardViewSetupSystem;
    

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        floorData = Resources.Load<FloorData>("Data/Floor/Floor" + FloorCounterSystem.FloorCount.ToString()); //+ FloorCounterSystem.FloorCount.ToString() +".asset");
        Debug.Log(floorData);
        if (!mainCamera) mainCamera = Camera.main;

        // If a FloorData asset is assigned in the inspector, populate from it on Start.
        if (floorData != null)
        {
            cardViewSetupSystem.CardViewSetup(floorData, cards);
        }
        UpdateCardPositions();
        FlipAllCards();
        cards[0].Flip();
    }

    private void Update()
    {
        HandleRaycastInput();
        if (cards.Count == 0)
        {
            SpawnDoorAtOrigin();
            doorSpawned = true;
        }
        CheckSpeed();
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
                if (cards.Exists(c => c.gameObject == hit.collider.gameObject))
                    validHits.Add(hit);
            }

            if (validHits.Count == 0) return;

            validHits.Sort((a, b) => a.distance.CompareTo(b.distance));

            int activeCount = Mathf.Min(2, validHits.Count);

            for (int i = 0; i < activeCount; i++)
            {
                GameObject hitCardGo = validHits[i].collider.gameObject;
                var cardflip = cards.Find(c => c.gameObject == hitCardGo);
                if (cardflip.isFlipped) return;
                Debug.Log($"Kattintott kártya: {hitCardGo.name}");
                RemoveFrontCard(hitCardGo);
            }
        }
    }

    void UpdateCardPositions(bool animate = false)
    {
        if (cards.Count == 0) return;

        // Ensure mainCamera is set (TestSystem may call CreateCards before RoundView.Start)
        if (!mainCamera)
            mainCamera = Camera.main;

        // Safe fallbacks if camera still not available
        Vector3 cameraPos = mainCamera != null ? mainCamera.transform.position : Vector3.zero;
        Vector3 cameraForward = mainCamera != null ? mainCamera.transform.forward : Vector3.forward;

        // If a spline is assigned, use it. Otherwise fall back to a simple circle around this transform.
        bool useSpline = circleSpline != null;

        for (int i = 0; i < cards.Count; i++)
        {
            float t = Mathf.Repeat(circleTOffset + (float)i / cards.Count, 1f);
            Vector3 targetPos;

            if (useSpline)
            {
                // spline returns world position
                targetPos = circleSpline.EvaluatePosition(t);
            }
            else
            {
                // fallback circular layout in world space around RoundView's transform
                float angle = t * Mathf.PI * 2f;
                Vector3 center = transform.position;
                // assume XZ-plane circle; keep same Y as center
                targetPos = center + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * fallbackRadius;
            }

            Vector3 cameraToTarget = (targetPos - cameraPos);
            // guard normalized on zero-length
            Vector3 cameraToTargetDir = cameraToTarget.sqrMagnitude > 0f ? cameraToTarget.normalized : Vector3.forward;
            bool isFront = Vector3.Dot(cameraForward, cameraToTargetDir) > 0.7f;
            if (isFront && mainCamera != null)
                targetPos += cameraForward * frontZOffset;

            cards[i].transform.position = targetPos;
            // make the card face the camera forward vector (keeps orientation consistent)
            cards[i].transform.rotation = Quaternion.LookRotation(cameraForward);
        }
        
    }

    /**
     * Flips all cards. Don't call in Update()!
     */
    void FlipAllCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Flip();
            //Debug.Log("flipped");
        }
    }

    public void RemoveFrontCard(GameObject clickedCard)
    {
        if (isMoving) return;

        CardView cv = cards.Find(c => c.gameObject == clickedCard);
        if (cv == null) return;

        StartCoroutine(RemoveAndShift(cv));
    }

    System.Collections.IEnumerator RemoveAndShift(CardView clickedCard)
    {
        isMoving = true;

        if (clickedCard != null)
        {
            // remove and destroy the view object
            cards.Remove(clickedCard);
            Destroy(clickedCard.gameObject);
        }

        // shift offset by the fraction based on the number of cards before removal
        circleTOffset += 1f / Mathf.Max(1, (cards.Count + 1));

        yield return null;

        isMoving = false;

        if (cards.Count > 0)
        {
            if(cards[0].isFlipped) cards[0].Flip();
            if(cards[^1].isFlipped) cards[^1].Flip();
        }
    }

    /**
     * Checks the player's speed stat and updates the enemies' visuals accordingly
     */
    void CheckSpeed()
    {
        for(int i = 0; i < cards.Count; i++)
        {

            int speed = 2; //replace with player's speed

            if (cards[i] is EnemyCardView enemyCardView)
            {
                if (enemyCardView.EnemyCard.Speed < speed)
                {
                    enemyCardView.speedUp.enabled = false;
                    enemyCardView.speedDown.enabled = true;
                }
                else
                {
                    enemyCardView.speedDown.enabled = false;
                    enemyCardView.speedUp.enabled = true;
                }
            }
        }
    }
    
    void SpawnDoorAtOrigin()
    {
        if (doorSpawned) return;
        DoorCard door = new DoorCard(doorCardData);
        DoorCardView doorView = 
            DoorCardViewCreator.Instance.CreateDoorCardView(door, Vector3.zero, Quaternion.identity);

        doorView.gameObject.SetActive(true);
        // stays at world (0,0,0) as requested
        doorSpawned = true;
    }


}
