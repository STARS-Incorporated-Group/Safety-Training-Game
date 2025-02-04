using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fires : MonoBehaviour
{
    public enum Type
    {
        ClassA,
        ClassB,
        ClassC,
        ClassD,
        Electrical,
        ClassF
    }
    
    public Type type { get; set; }
    public float intensity { get; set; }
    
    public bool extinguishes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
