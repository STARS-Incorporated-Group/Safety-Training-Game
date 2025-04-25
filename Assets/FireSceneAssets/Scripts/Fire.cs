using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    public float GetIntensity() => currentIntensity;

    private float[] startIntensities = new float[0];
    float nextRegenTime = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;
    
    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    private bool isLit = true;

    private void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];

        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
    }

   

    private void Update()
    {
        if (isLit && currentIntensity < 1.0f)         
            Regenerate();          
    }

    private void Regenerate() 
    {
        if (Time.time < nextRegenTime)
            return;

        currentIntensity += regenRate * Time.deltaTime;
        ChangeIntensity();
    }

    public bool TryExtinguish(float amount) 
    {
        nextRegenTime = Time.time + regenDelay;

        currentIntensity -= amount;

        ChangeIntensity();

        if (currentIntensity <= 0) 
        {
            Die();
            return true;
        }

        

        return false; //fire is still lit
    }

    private void Die() 
    {
        isLit = false;
        enabled = false;
    }

    private void ChangeIntensity() 
    {
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
