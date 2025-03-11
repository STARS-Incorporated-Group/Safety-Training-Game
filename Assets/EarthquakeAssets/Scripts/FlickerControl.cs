using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    private float timer;

    public Renderer objRenderer;
    private Material objMaterial;
    private bool isEmissionOn = true;
    private float gameStartTime;
    private float endLight;
    private float startFlicker;

    private bool isFlicker = false;

    public AnimationCurve timeDistribution;

    private Rigidbody rb;

    public AudioSource flickerSound;
    private bool soundPlaying = false;

    void Start()
    {
        timer = Random.Range(0.1f, 2.2f);

        endLight = Random.Range(25f, 60f);
        Debug.Log("end" + endLight);

        startFlicker = Random.Range(5f, 30f);

        gameStartTime = Time.time;

        if (objRenderer == null)
        {
            objRenderer = GetComponent<Renderer>();
        }
        
        if (objRenderer != null)
        {
            objMaterial = objRenderer.material;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // sound
        if (Time.time > startFlicker && soundPlaying == false)
        {
            flickerSound.Play();
            soundPlaying = true;
        }

        /*if (Time.time > gameStartTime + 5f)
        {
            MakeDynamic();
            this.enabled = false;
        }*/
        if (Time.time > gameStartTime + endLight)
        {
            float c = Random.Range(0f, 1f);
            Debug.Log("c" + c);
            if (c > 0.5f)
            {
                this.gameObject.GetComponent<Light>().enabled = false;
                objMaterial.DisableKeyword("_EMISSION");
                float b = Random.Range(0f, 1f);
                Debug.Log("b" + b);
                if (b > 0.5f)
                {
                    MakeDynamic();
                }
                this.enabled = false;
            }
        }

        if (isFlicker == false)
        {
            if (Time.time > gameStartTime + startFlicker)
            {
                isFlicker = true;
            }
        }
        else
        {
            LightsFlickering();
        }
    }

    void LightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            this.gameObject.GetComponent<Light>().enabled = !this.gameObject.GetComponent<Light>().enabled;
            
            if (isEmissionOn == true)
            {
                objMaterial.DisableKeyword("_EMISSION");
                isEmissionOn = false;
            }
            else
            {
                objMaterial.EnableKeyword("_EMISSION");
                isEmissionOn = true;
            }

            float randomValue = Random.value; // Random value between 0 and 1
            float curveValue = timeDistribution.Evaluate(randomValue); // Map through curve
            timer = curveValue;
        }
    }

    void MakeDynamic()
    {
        gameObject.isStatic = false;
        
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.mass = 5f;
    }
}
