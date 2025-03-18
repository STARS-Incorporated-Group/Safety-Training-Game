// attach this script to the fire source prefab
// set the firePrefab to the fire prefab you want to instantiate when the fire spreads
// set the spreadTime to the desired time to spread the fire
// set the tag of the fire source to "FireSource"

using UnityEngine;

public class FireSpread : MonoBehaviour {
    public GameObject firePrefab; 
    public float spreadTime = 5.0f;
    private bool isBurning = false;

    private void Start(){
        InvokeRepeating("SpreadFire", spreadTime, spreadTime);
    }

    private void OnTriggerEnter(Collider other) { // called when the fire source collides with another object

        if (other.CompareTag("FireSource") && !isBurning) {
            StartBurning();
        }
    }
    private void SpreadFire(){ // called every spreadTime seconds to spread the fire

        if (isBurning) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);
            
            foreach (var hitCollider in hitColliders) {
                if (hitCollider.CompareTag("Flammable")) { // check if the object is flammable
                    Instantiate(firePrefab, hitCollider.transform.position, Quaternion.identity);
                }
            }
        }
    }


    private void StartBurning(){ // called when the fire source collides with another object
        isBurning = true;
        Instantiate(firePrefab, transform.position, Quaternion.identity);
    }
}