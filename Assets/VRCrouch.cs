using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;


public class VRCrouch : MonoBehaviour
{
    public XROrigin xrOrigin;  // Reference to XR Origin
    public float standingHeight = 1.6f; // Approximate standing height
    public float crouchThreshold = 1.2f; // Height to trigger crouch
    public float crouchHeight = 0.8f; // Crouched camera height
    public float smoothSpeed = 5f; // Smooth transition speed

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float headHeight = xrOrigin.CameraInOriginSpaceHeight;
        float targetHeight = (headHeight < crouchThreshold) ? crouchHeight : standingHeight;
        
        // Smoothly adjust the Character Controller height
        characterController.height = Mathf.Lerp(characterController.height, targetHeight, Time.deltaTime * smoothSpeed);

        // Adjust Y position to prevent floating or sinking
        Vector3 center = characterController.center;
        center.y = characterController.height / 2;
        characterController.center = center;
    }
}
