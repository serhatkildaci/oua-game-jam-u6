using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float minIntensity = 0.1f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 5f;

    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        float flicker = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        light.intensity = Mathf.Lerp(minIntensity, maxIntensity, flicker);
    }
}
