using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Patrol patrol;

    bool walking = false;

    [Header("body parts")]
    [SerializeField] List<Swinger> swingers;

    public void Start(){
        
        foreach(Swinger s in GetComponentsInChildren<Swinger>()){
            swingers.Add(s);
        }

        foreach(Candle c in GetComponentsInChildren<Candle>()){
        c.OnExtinguish += StopWalking;
        c.OnLight +=  StartWalking;
        }
    }
    public void StartWalking(){
        foreach(Swinger s in swingers){
            s.Play();
        }
    }

    public void StopWalking(){
        foreach(Swinger s in swingers){
            s.Stop();
        }
    }
}
