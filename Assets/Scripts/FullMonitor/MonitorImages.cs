using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorImages : MonoBehaviour
{
    public Animator animator;

    public bool charactersPressed = false;
    public bool roundPressed = false;
    public bool tv0Pressed = false;

    public HoverTvG[] hovers;
    public PeopleButton peopleButton;

    public bool onCharScreen;
    public bool onRoundScreen;
    public bool onTv0Screen;
    public bool screenSwitch;
     

    //Start method that declares variables to work similarly to Monitor.cs (mini monitor)
    void Start(){
        onCharScreen = false;
        onRoundScreen = true;
        screenSwitch = false;
        onTv0Screen = false;



    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("roundToChar", false);
        animator.SetBool("charToRound", false);

        if ((charactersPressed || tv0Pressed) && onRoundScreen) {  
            if (charactersPressed){   
                animator.SetBool("roundToChar", true);
                onRoundScreen = false;
                onCharScreen = true;

                charactersPressed = false;
            } else if (tv0Pressed){
                tv0Pressed = false;

                gameObject.GetComponent<Renderer>().enabled = false;

                onRoundScreen = false;
                onTv0Screen = true;
            }

            //Debug.Log("round to char ");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = false;
            }
        }
        if((roundPressed && onCharScreen) || (onTv0Screen && peopleButton.checkButtonPressed)) {

            if(onCharScreen){
                animator.SetBool("charToRound", true);
                onCharScreen = false;
                onRoundScreen = true;

                roundPressed = false;
            } else if(onTv0Screen){
                onTv0Screen = false;
                peopleButton.checkButtonPressed = false;
                onRoundScreen = true;

                gameObject.GetComponent<Renderer>().enabled = true;
            }

            
            //Debug.Log("char to round");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = true;
            }
            
        }
    }
}
