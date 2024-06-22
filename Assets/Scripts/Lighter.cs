using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour{

    Vector3 thumbRot;

    public ParticleSystem particles;
    public SpriteRenderer icon;

    public Sprite mouseDown;
    public Sprite mouseEnter;
    public Sprite mouseExit;
   
    public Transform thumb;

    public Flame flame;
    public static Lighter i;

    public void Awake(){
        i = this;
        thumbRot = thumb.eulerAngles;
    }

    public void Update(){

        if(Input.GetMouseButtonDown(0)){
            
            MouseDown();
        }

        if(Input.GetMouseButtonUp(0)){
            
            MouseUp();
        }
    }

    public void MouseEnter(){
        icon.sprite = mouseEnter;
    }

     public void MouseExit(){
        icon.sprite = mouseExit;

    }

    public void MouseUp(){
        //flame.Extinguish();
        thumb.Rotate(Vector3.up * 30);
    }

    public void MouseDown(){
        particles.Play();
        thumb.Rotate(Vector3.up * -30);

    }
}
