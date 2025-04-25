using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float extinguishRate = 1.0f; //amount of fire extinguished per second

    [SerializeField] private Transform raycastOrigin = null;

    [Space, Header("Steam")]
    [SerializeField] private GameObject steamObject = null;

    private bool IsRaycastingSomething(out RaycastHit hit) => Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 100f);

    private bool IsRaycastingFire(out Fire fire) 
    {
        fire = null;

        return IsRaycastingSomething(out RaycastHit hit) && hit.collider.TryGetComponent(out fire);
    }

    private void Start()
    {
        if (!steamObject)
            Debug.LogError("Please place a steam particle system on the Extinguisher's steamObject field or rewrite the Extinguisher script.", this);
    }

    private void Update()
    {
        if (IsRaycastingFire(out Fire fire))
            ExtinguishFire(fire);
        else if (steamObject.activeSelf)
            steamObject.SetActive(false);
    }

    private void ExtinguishFire(Fire fire) 
    {
        fire.TryExtinguish(extinguishRate * Time.deltaTime);

        steamObject.transform.position = fire.transform.position;
        steamObject.SetActive(fire.GetIntensity() > 0.0f);
    }
}
