using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayHose : MonoBehaviour
{

    public Transform spraySpawnPoint;
    public GameObject waterStreamPrefab;
    public GameObject waterStreamSpawnPoint;

    private bool isSpraying = false;

    // Start is called before the first frame update
    void Start()
    {
        // Bring Water Stream Prefab to waterStreamSpawnPoint
        // Hide it (make it not there until activated)

        // Instantiate and deactivate the water stream at start
        waterStreamInstance = Instantiate(waterStreamPrefab, spraySpawnPoint.position, spraySpawnPoint.rotation, spraySpawnPoint);
        waterStreamInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Once Button A on the Oculus Quest 3's XR Controller (A Button) is pressed, enable the water stream object
        
        // Check if A button is pressed on the right controller
        if (Gamepad.current != null)
        {
            // Optional: fallback for regular Gamepad testing
            isSpraying = Gamepad.current.buttonSouth.isPressed; // "A" on Xbox
        }
        else
        {
            var rightHand = InputSystem.GetDevice<UnityEngine.InputSystem.XR.XRController>(CommonUsages.RightHand);
            if (rightHand != null)
            {
                InputDevice device = rightHand;
                bool aButtonValue;
                if (device.TryGetFeatureValue(CommonUsages.primaryButton, out aButtonValue))
                {
                    isSpraying = aButtonValue;
                }
            }
        }

        if (waterStreamInstance != null)
        {
            waterStreamInstance.SetActive(isSpraying);
        }
    }
}
