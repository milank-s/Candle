using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Candle candle;

    [Header("FX")]
    [SerializeField] GameObject lightOnState;
    [SerializeField] GameObject loseState;

    [Header("SFX")]
    [SerializeField] AudioClip lightOutBark;

    void Start()
    {
        foreach(Candle c in GetComponentsInChildren<Candle>()){
            c.OnExtinguish += LightOff;
            c.OnLight += LightOn;
        }

    }

    void Update(){

    }

    public void Lose(){
    }

    public void LightOn(){

    }

    public void LightOff(){

    }
}
