using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Candle : MonoBehaviour
{

    //TODO

    //add lighting sound
    //add extinguishing sound

    public Flame flame;
    public bool isLit = false;
    public float lifeTime = 10f; // Maximum duration in seconds the candle stays lit
    private float currentDuration = 0f;
    private bool timerRunning = false;

    public delegate void Event();

    public Event OnExtinguish;

    public Event OnLight;

    void Start()
    {
        isLit = true;
        timerRunning = true;
    }

    public void OnMouseEnter(){
        
        
        Lighter.i.MouseEnter();
    }

    public void OnMouseExit(){
        Lighter.i.MouseExit();
    }

    public void OnMouseDown(){
        
        LightCandle();
    }

    void Update()
    {
        // Update the timer if the candle is lit and the timer is running
        if (isLit && timerRunning)
        {
            currentDuration += Time.deltaTime;
            flame.intensity = 1-(currentDuration/lifeTime);
            if (currentDuration >= lifeTime)
            {
                ExtinguishCandle();
            }
        }
    }

    public void LightCandle()
    {
        if(OnLight != null){
            OnLight.Invoke();
        }
        isLit = true;
        flame.Light();
        currentDuration = 0f; // Reset the timer
        timerRunning = true;
    }

    public void ExtinguishCandle()
    {
        if(OnExtinguish != null){
            OnExtinguish.Invoke();
        }
        
        isLit = false;
        flame.Extinguish();
        timerRunning = false;
    }
}