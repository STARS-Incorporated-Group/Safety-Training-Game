using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CrouchDetector : MonoBehaviour
{
    public float crouchThreshold = 0.3f; // How much shorter the head must be to count as crouching
    public Vector3 crouchScale = new Vector3(1.25f, 0.4f, 1.25f);
    public Vector3 normalScale = new Vector3(1.25f, 2f, 1.25f);
    public float scaleSmoothSpeed = 3f;

    public bool isCrouching = false;

    private float initialHeadHeight;
    private Vector3 targetScale;

    void Start()
    {
        Debug.Log("CrouchDetector initialized (XRNode mode).");

        // Get initial head height from XR headset
        if (TryGetHeadsetHeight(out float currentHeight))
        {
            initialHeadHeight = currentHeight;
            Debug.Log($"Initial headset height recorded: {initialHeadHeight:F2}m");
        }
        else
        {
            Debug.LogError("Could not get initial headset height.");
        }

        targetScale = normalScale;
    }

    void Update()
    {
        if (!TryGetHeadsetHeight(out float currentHeight))
        {
            Debug.LogWarning("Unable to read headset height.");
            return;
        }

        // Check crouch
        if (currentHeight < initialHeadHeight - crouchThreshold && !isCrouching)
        {
            isCrouching = true;
            targetScale = crouchScale;
            Debug.Log("Crouch detected. Scaling down.");
        }
        else if (currentHeight >= initialHeadHeight - crouchThreshold && isCrouching)
        {
            isCrouching = false;
            targetScale = normalScale;
            Debug.Log("Standing detected. Scaling up.");
        }

        // Smooth scale transition
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSmoothSpeed);
    }

    bool TryGetHeadsetHeight(out float height)
    {
        List<XRNodeState> nodeStates = new List<XRNodeState>();
        InputTracking.GetNodeStates(nodeStates);

        foreach (XRNodeState nodeState in nodeStates)
        {
            if (nodeState.nodeType == XRNode.Head && nodeState.TryGetPosition(out Vector3 headPos))
            {
                height = headPos.y;
                return true;
            }
        }

        height = 0f;
        return false;
    }
}
