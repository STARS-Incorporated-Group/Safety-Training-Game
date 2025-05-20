using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CrouchDetector : MonoBehaviour
{
    public Camera mainCamera; // Assign this manually in the Inspector
    public float crouchThreshold = 0.2f; // Difference in height to consider as crouch
    public Vector3 crouchScale = new Vector3(0.4f, 0.4f, 0.4f);
    public Vector3 normalScale = new Vector3(1.25f, 1.25f, 1.25f);
    public float scaleSmoothSpeed = 5f; // Higher = faster transitions

    public bool isCrouching { get; private set; }

    private Transform headTransform;
    private float startHeight;
    private Vector3 targetScale;

    void Start()
    {
        Debug.Log("CrouchDetector initialized.");

        if (mainCamera == null)
        {
            Debug.LogWarning("MainCamera not assigned! Trying to find Main Camera...");
            mainCamera = Camera.main;

            if (mainCamera != null)
            {
                Debug.Log("Main Camera found and assigned.");
            }
            else
            {
                Debug.LogError("No Main Camera found! Assign it manually in the Inspector.");
                return;
            }
        }

        headTransform = mainCamera.transform;
        startHeight = headTransform.position.y;
        targetScale = transform.localScale; // Initialize to current scale
    }

    void Update()
    {
        if (headTransform == null)
        {
            Debug.LogError("HeadTransform is null! Ensure the Main Camera is assigned.");
            return;
        }

        float headHeight = headTransform.position.y;
        bool crouchDetected = headHeight < startHeight - crouchThreshold;

        if (crouchDetected && !isCrouching)
        {
            isCrouching = true;
            targetScale = crouchScale;
            Debug.Log("Crouch detected. Scaling down.");
        }
        else if (!crouchDetected && isCrouching)
        {
            isCrouching = false;
            targetScale = normalScale;
            Debug.Log("Standing detected. Scaling up.");
        }

        // Smooth transition
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSmoothSpeed);
    }
}
