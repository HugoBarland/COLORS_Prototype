using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    bool roulettePressed = false;
    bool startRotating;
    bool reducingSpeed = false;
    private float rotZ;
    public float rotationSpeed;

    public EliminatedMessage elimMessage;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && roulettePressed) {
            roulettePressed = false;
            if (!startRotating){
                startRotating = true;
            } else {
                reducingSpeed = true;
            }
        }

        if (startRotating && (rotationSpeed > 0)){
            rotZ += Time.deltaTime * (rotationSpeed/100);
            if (reducingSpeed && (rotationSpeed > 0))
                rotationSpeed = rotationSpeed - 10;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            if (rotationSpeed <= 0){
              eliminatedColor(rotZ%360);
            }
        }
    }

    void OnMouseDown(){ 
        roulettePressed = true;
    }

    void eliminatedColor(float num){
        //60 green, 120 blue, 180 yellow, 240 black, 300 pink, 360 red
        string[] degrees = {"Green", "Blue", "Yellow", "Black", "Pink", "Red"};

        Debug.Log(degrees[(int)num/60] + " has been eliminated");
        elimMessage.numCharEliminated = (int)num/60;
        elimMessage.animator.SetBool("eliminatedMessageOn", true);
        
    }
}
