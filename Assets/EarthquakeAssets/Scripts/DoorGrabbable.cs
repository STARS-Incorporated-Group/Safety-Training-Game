using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabbable : XRGrabInteractable
{
    public Transform handler;

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        rbhandler.velocity = Vector3.zero;
        rbhandler.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if(Vector3.Distance(handler.position, transform.position) > 0.4f)
        {
            GetComponent<XRBaseInteractor>().allowSelect = false;
        }
    }
}
