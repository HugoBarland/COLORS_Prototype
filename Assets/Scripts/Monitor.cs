using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public Animator animator;

    public bool redPressed = false;

    public bool monitorPressed = false;
    public bool animationEnded = false;

    public bool onCharScreen = false;
    public bool screenSwitch = false;

    // Update is called once per frame
    void Update()
    {
        animationEnded = animator.GetBool("animationEnded");
        if (redPressed) {
            turnOn();
        }
        if (Input.GetMouseButtonDown(0) && monitorPressed && animationEnded) {
            Camera.main.transform.Translate(0,-2.78f,0);
            monitorPressed = false;
        }
        if(redPressed && screenSwitch) {
            if(onCharScreen){
                animator.SetBool("onCharScreen", true);
                screenSwitch = false;
            } else {
                animator.SetBool("onCharScreen", false);
                screenSwitch = false;
            }
        }

    }

    private void turnOn(){
        animator.SetBool("monitorOn", true);
    }

    // Remember to add the 2D collider to be able to make this method work.
    void OnMouseDown(){ 
        monitorPressed = true;
    }
}
