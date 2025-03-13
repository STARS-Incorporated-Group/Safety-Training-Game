// attach sprite to fire extinguisher prefab and set tag to "Fire"
// attach this script to the fire extinguisher prefab
// set the extinguishTime to the desired time to extinguish the fire
// set the tag of the fire to "Fire"

using UnityEngine;
using System.Collections;

public class FireExtinguisherEffect : MonoBehaviour{
    public float extinguishTime = 3.0f;

    private void OntriggerStay(Collider other){ // called when the fire extinguisher is in contact with another object

        if (other.CompareTag("Fire") && Input.GetButton("Fire1")) { // check if the object is a fire and the player is pressing the fire button
        
            StartCoroutine(ExtinguishFire(other.gameObject));
            Debug.Log("Extinguishing fire");
        }
    }
    private IEnumerator ExtinguishFire(GameObject fire){ // called when the fire extinguisher is in contact with a fire

        yield return new WaitForSeconds(extinguishTime);
        if (fire != null) {
            Destroy(fire);
            Debug.Log("Fire extinguished"); // destroy the fire object after the extinguish time has passed

            // play extinguish sound effect here
        }
    }
}