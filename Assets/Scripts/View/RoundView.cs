using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class RoundView : MonoBehaviour
{
    public SplineContainer circleSpline;
    //[SerializeField] private FloorData floorData; // assign in inspector or call PopulateFromFloor manually
    [SerializeField] public DoorCardData doorCardData;
    [SerializeField] private GameObject victoryScreen;

    [SerializeField] private CardViewSetupSystem cardViewSetupSystem;
    [SerializeField] private RemoveCardSystem RemoveCardSystem;
    [SerializeField] private FloorSelectSystem FloorSelectSystem;

    public static Camera mainCamera;
    public float frontZOffset = 0.2f;
    public float circleTOffset = 0f;
    public float fallbackRadius = 2f;
    public static float rnd;
    public static bool lastFloorWasSpecial;
    public static bool lastFloorWasEncounter;


    // store CardView instances instead of raw GameObjects
    public static List<CardView> cards = new List<CardView>();
    public static bool doorSpawned = false;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        rnd = UnityEngine.Random.value;
        if (!mainCamera) mainCamera = Camera.main;
        doorSpawned = false;
        StartCoroutine(StartUp());
    }

    private void Update()
    {
        HandleRaycastInput();
        //Change the number in this if statement if more floors are added, also change it in FloorSelectSystem
        if (cards.Count == 0 && FloorCounterSystem.FloorCount > 5)
        {
            victoryScreen.SetActive(true);
        }
    }

    IEnumerator StartUp()
    {
        //Loading the resources in FloorSelectSystem's Start() MUST happen first, thus the wait
        yield return new WaitForSeconds(0.01f);
        UpdateCardPositions();
        if (cards.Count > 0)
        {
            FlipAllCards();
            cards[0].Flip();
        }
    }

    void HandleRaycastInput()
    {
        if (RemoveCardSystem.isMoving || cards.Count == 0) return;

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

                // Only run enemy turn for EnemyCardView instances
                var enemyView = hitCardGo.GetComponent<EnemyCardView>();
                if (enemyView != null)
                {
                    EnemyTurnGA enemyTurnGA = new(enemyView);
                    ActionSystem.Instance.Perform(enemyTurnGA);
                }

                
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
}
