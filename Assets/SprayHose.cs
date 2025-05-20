using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SprayHose : MonoBehaviour
{

    // public GameObject waterStreamPrefab;
    // public GameObject waterStreamSpawnPoint;
    // public Transform spraySpawnPoint = waterStreamSpawnPoint.Transform;
    public Transform spraySpawnPoint;

    public GameObject waterStreamObject;

    public bool isSpraying = true;

    
    // private GameObject waterStreamInstance;        // The active stream instance

    // Start is called before the first frame update
    void Start()
    {
        // Bring Water Stream Prefab to waterStreamSpawnPoint
        // Hide it (make it not there until activated)

        // Instantiate and deactivate the water stream at start
        // waterStreamInstance = Instantiate(waterStreamPrefab, spraySpawnPoint.position, spraySpawnPoint.rotation, spraySpawnPoint);
        // waterStreamInstance.SetActive(false);

        waterStreamObject.SetActive(false); // change to false
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.isValid)
        {
            bool thumbstickPressed = false;
            if (rightHand.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out thumbstickPressed))
            {
                isSpraying = thumbstickPressed;
                print(isSpraying);
            }
        }

        waterStreamObject.SetActive(isSpraying);

        // if (waterStreamInstance != null)
        // {
        //     // waterStreamInstance.SetActive(isSpraying); // todo
        // }
    }
}
