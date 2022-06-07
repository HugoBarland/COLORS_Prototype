using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public Animator animator;

    public bool redPressed = false;

    public bool monitorPressed = false;
    public bool animationEnded = false;

    public bool onCharScreen;
    public bool onRoundScreen;
    public bool screenSwitch;

    void Start(){
        onCharScreen = false;
        onRoundScreen = true;
        screenSwitch = false;
    }

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
            //Debug.Log(" 4 ");
            if(onCharScreen){
                animator.SetBool("onCharScreen", true);

                animator.SetBool("onRoundScreen", false);
                screenSwitch = false;
            }
            if(onRoundScreen) {
                animator.SetBool("onRoundScreen", true);

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
