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
    public HeadToken headtoken;

    public bool onCharScreen;
    public bool onRoundScreen;
    public bool onTv0Screen;
    public bool screenSwitch;
    public bool redButtonScreenPressed;//true once the pairs have been decided and red button has been pressed.


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
        animator.SetBool("roundToTv0", false);
        animator.SetBool("Tv0ToRound", false);
        animator.SetBool("Tv0ToRedButton", false);
        animator.SetBool("redButtonToTv0", false);

        if ((charactersPressed || tv0Pressed) && onRoundScreen) {  
            if (charactersPressed){   
                animator.SetBool("roundToChar", true);
                onRoundScreen = false;
                onCharScreen = true;

                charactersPressed = false;
            } else if (tv0Pressed){
                tv0Pressed = false;
                //gameObject.GetComponent<Renderer>().enabled = false;
                //enabling the Sprite Render component on tokens.
                for (int i = 0; i < headtoken.ts.Length; i++){
                    headtoken.ts[i].GetComponent<Renderer>().enabled = true;
                    if (!redButtonScreenPressed){
                        headtoken.ts[i].GetComponent<Collider2D>().enabled = true;
                    }
                }
                animator.SetBool("roundToTv0", true);
                onRoundScreen = false;
                onTv0Screen = true;
            }

            //Debug.Log("round to char ");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = false;
            }
        }
        if((roundPressed && onCharScreen) || (onTv0Screen && peopleButton.checkButtonPressed && redButtonScreenPressed)) {

            if(onCharScreen){
                animator.SetBool("charToRound", true);
                onCharScreen = false;
                onRoundScreen = true;

                roundPressed = false;
            } else if(onTv0Screen){
                // disabling tokens' sprite renderer component in loop.
                for (int i = 0; i < headtoken.ts.Length; i++){
                    headtoken.ts[i].GetComponent<Renderer>().enabled = false;
                    headtoken.ts[i].GetComponent<Collider2D>().enabled = false;
                }
                animator.SetBool("Tv0ToRound", true);
                onTv0Screen = false;
                peopleButton.checkButtonPressed = false;
                onRoundScreen = true;

                //gameObject.GetComponent<Renderer>().enabled = true;
            }

            
            //Debug.Log("char to round");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = true;
            }
            
        }

        if (onTv0Screen && peopleButton.checkButtonPressed && !redButtonScreenPressed){
            for (int i = 0; i < headtoken.ts.Length; i++){
                    headtoken.ts[i].GetComponent<Renderer>().enabled = false;
                    headtoken.ts[i].GetComponent<Collider2D>().enabled = false;
                }
            animator.SetBool("Tv0ToRedButton", true);
            onTv0Screen = false;
            peopleButton.checkButtonPressed = false;

           
            
        }
    }
}
