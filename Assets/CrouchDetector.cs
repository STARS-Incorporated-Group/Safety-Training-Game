using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;




public class CrouchDetector : MonoBehaviour
{
    public Camera mainCamera; // Assign this manually in the Inspector
    public float crouchThreshold = 1.2f; // Adjust threshold for crouching
    public bool isCrouching; // { get; private set; } // Read-only outside this class
   


    private Transform headTransform; // Stores the transform of the camera


    void Start()
    {
        UnityEngine.Debug.unityLogger.logEnabled = true;


        UnityEngine.Debug.Log("Test message: The script has started!");


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
    }


    void Update()
    {
        if (headTransform != null)
        {
            float headHeight = headTransform.position.y;
            isCrouching = headHeight < crouchThreshold;

            Debug.Log($"Current Headset Height: {headHeight}, Crouching: {isCrouching}");
        }
        else
        {
            Debug.LogError("HeadTransform is null! Ensure the Main Camera is assigned.");
        }
    }
}

