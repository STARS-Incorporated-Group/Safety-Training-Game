using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterGlass : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Vector3 randomForceDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddForce(randomForceDirection * 7f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
