using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EarthquakeSound : MonoBehaviour
{
    public EarthquakeShake earthquakeShake; // Reference to the earthquake script
    private AudioSource earthquakeAudio;     // Reference to the AudioSource

    public float maxVolume = 1f;             // Maximum audio volume

    void Start()
    {
        earthquakeAudio = GetComponent<AudioSource>();
        earthquakeAudio.loop = true;
        earthquakeAudio.volume = 0f;         // Start with volume muted
        earthquakeAudio.Play();
    }

    void FixedUpdate()
    {
        // Match audio volume to earthquake intensity as a percentage with exponential scaling
        float intensityPercentage = earthquakeShake.shakeIntensity / earthquakeShake.maxShakeIntensity;
        earthquakeAudio.volume = Mathf.Clamp(Mathf.Pow(intensityPercentage, 1.5F) * maxVolume, 0f, maxVolume);
    }
}



