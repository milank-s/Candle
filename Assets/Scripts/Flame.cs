using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{

    public float intensity = 1;
    public float range = 10;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Light light;

    public float flickerFrequency = 5;

    float noiseX, noiseY;

    public void Start(){
        noiseX = Random.Range(-10f, 10f);
        noiseY = Random.Range(-10f, 10f);
    }

    public void Update(){

        float noise = Mathf.PerlinNoise(noiseX * Time.time * flickerFrequency, noiseY + Time.time * flickerFrequency);
        light.range = Mathf.Lerp(0, range, intensity) + noise;
        light.intensity = intensity + noise;
        
        transform.localScale = Vector3.one * noise;
    }
    public void Extinguish(){
        sprite.enabled = false;
        light.enabled = false;
    }

    public void Light(){
        light.enabled = true;
        sprite.enabled = true;
    }
}
