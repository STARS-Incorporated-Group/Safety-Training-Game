using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterGlass : MonoBehaviour
{

    public float x,y,z;
    public GameObject shatters;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var newpos = gameObject.transform.TransformPoint(pos) + new Vector3(x, y, z);
        shatters.transform.position = newpos;
        shatters.SetActive(true);
        gameObject.SetActive(false);
    }
}
