using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EarthquakeShake : MonoBehaviour
{
    private float initialShakeIntensity = 0f;  // Starting intensity
    public float maxShakeIntensity = 20f;     // Maximum intensity
    private float intensityIncreaseDuration = 45f; // Time (in seconds) to reach max intensity and back to 0
    private float intensityDecreaseDuration = 15f;
    private float startDelay = 0f;             // Delay (in seconds) before shaking starts
    private int frequency = 5;                 // Frequency for shaking

    public AnimationCurve shakeDistribution; // AnimationCurve for controlling randomness

    private Rigidbody rb;                    // Reference to the Rigidbody
    private int counter = 0;
    private float elapsedTime = 0f;          // Tracks time since shaking started
    public float shakeIntensity = 0f;       // Current intensity
    private float gameStartTime;             // Tracks the time the game starts

    private int collisionCount = 0;          // Tracks number of colliding objects
    private bool isIncreasing = true;        // Controls intensity increase/decrease

    private XRGrabInteractable grabInteractable;
    private bool isBeingHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameStartTime = Time.time;

        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        collisionCount++;
    }

    void OnCollisionExit(Collision other)
    {
        collisionCount = Mathf.Max(0, collisionCount - 1); // Ensure it doesn't go negative
    }

    void FixedUpdate()
    {
        if (Time.time < gameStartTime + startDelay || collisionCount == 0 || isBeingHeld)
        {
            return;
        }

        // Adjust intensity over time
        if (isIncreasing)
        {
            elapsedTime += Time.fixedDeltaTime;
            shakeIntensity = Mathf.Lerp(initialShakeIntensity, maxShakeIntensity, elapsedTime / intensityIncreaseDuration);

            if (shakeIntensity >= maxShakeIntensity)
            {
                shakeIntensity = maxShakeIntensity;
                isIncreasing = false; // Start decreasing intensity
                elapsedTime = 0f; // Reset time for decrease phase
            }
        }
        else
        {
            elapsedTime += Time.fixedDeltaTime;
            shakeIntensity = Mathf.Lerp(maxShakeIntensity, 0f, elapsedTime / intensityDecreaseDuration);

            if (shakeIntensity <= 0f)
            {
                shakeIntensity = 0f;
                return; // Stop shaking completely
            }
        }

        counter++;

        if (counter >= frequency)
        {
            float randomValue = Random.value; // Random value between 0 and 1
            float curveValue = shakeDistribution.Evaluate(randomValue); // Map through curve

            // Scale the shake force based on the curve and current shake intensity
            Vector3 shakeForce = Random.insideUnitSphere * shakeIntensity * curveValue;

            rb.AddForce(shakeForce, ForceMode.Impulse);

            counter = 0;
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isBeingHeld = true;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isBeingHeld = false;
    }
}
