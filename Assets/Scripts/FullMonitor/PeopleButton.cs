
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleButton : MonoBehaviour
{
    public bool peopleBPressed = false;
    public bool tv0Pressed = false;
    public bool onTv0Screen = false;
    public Animator animator;

    public MonitorImages monitorImage;
    public Monitor miniMonitor;
    public redButton redButton;
    public HoverPair[] hoverpair;

    public bool checkButtonPressed = false;


    // Update is called once per frame
    void Update()

    {
        animator.SetBool("CharButtonPressed", false);
        animator.SetBool("RoundButtonPressed", false);
        animator.SetBool("CheckButtonPressed", false);
        animator.SetBool("Tv0ButtonPressed", false);




        if (!onTv0Screen && Input.GetMouseButtonDown(0) && peopleBPressed) {

            
            peopleBPressed = false;

            if(monitorImage.onRoundScreen){
                animator.SetBool("CharButtonPressed", true);
                monitorImage.charactersPressed = true;
            } else if(monitorImage.onCharScreen){
                animator.SetBool("RoundButtonPressed", true);
                monitorImage.roundPressed = true;
            }
          
             //Debug.Log(" 1 ");



            miniMonitor.screenSwitch = true;
            if (miniMonitor.onCharScreen) {

                miniMonitor.onRoundScreen = true;

                miniMonitor.onCharScreen = false;

            } else if (miniMonitor.onRoundScreen) {

                miniMonitor.onCharScreen = true;

                miniMonitor.onRoundScreen = false;
            }
        } else if(onTv0Screen && Input.GetMouseButtonDown(0) && peopleBPressed){
            peopleBPressed = false;
            onTv0Screen = false;
            checkButtonPressed = true;
            animator.SetBool("CheckButtonPressed", true);

            miniMonitor.animator.SetBool("onTv0", false);
            if (!monitorImage.redButtonScreenPressed){
                miniMonitor.animator.SetBool("onPressRedButton", true);
                gameObject.GetComponent<Renderer>().enabled = false;
                redButton.startTv0 = true;
            } else {
                animator.SetBool("firstCheckPressed", true);
                miniMonitor.animator.SetBool("onTv0", false);
                miniMonitor.animator.SetBool("onRoundScreen", true);
                
                for (int i = 0; i < hoverpair.Length; i++){
                    hoverpair[i].screenChanged = true;
                    hoverpair[i].colliderOn = false;
                }            
            }
     

        }else if(tv0Pressed){
            tv0Pressed = false;
            onTv0Screen = true;
            animator.SetBool("Tv0ButtonPressed", true);

        }
    }

  

    // Detects whether peopleButton GameObject has been pressed

    void OnMouseDown(){ 
        peopleBPressed = true;
    }


 
}
