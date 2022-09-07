using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redButton : MonoBehaviour
{
    public Animator animator;

    public WaypointScript1 chair0;
    public WaypointScript1 chair1;
    public WaypointScript1 chair2;
    public WaypointScript1 chair3;
    public WaypointScript1 chair4;
    public WaypointScript1 chair5;

    public Monitor mt;
    public MonitorImages monitorImage;
    public PeopleButton peopleButton;
    public ConversationController conversationControl;
    public HeadToken headtoken;
    public HoverPair[] hoverpair;
    bool displayFirstConversation = true; //meant to be used only once.

    public bool redSelected = false;
    public bool startTv0 = false;
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("pressed", false);
        
        if (Input.GetMouseButtonDown(0) && redSelected) {
            animator.SetBool("pressed", true);
            chair0.movingChairs = true;
            chair1.movingChairs = true;
            chair2.movingChairs = true;
            chair3.movingChairs = true;
            chair4.movingChairs = true;
            chair5.movingChairs = true;

            mt.redPressed = true;
            if (displayFirstConversation) {
                conversationControl.startConversationTrigger = true;
                displayFirstConversation = false;
            }

            if (startTv0){
                startTv0 = false;
                chair0.animator.SetBool("closingCapsule", true);
                chair1.animator.SetBool("closingCapsule", true);
                chair2.animator.SetBool("closingCapsule", true);
                chair3.animator.SetBool("closingCapsule", true);
                chair4.animator.SetBool("closingCapsule", true);
                chair5.animator.SetBool("closingCapsule", true);

                mt.animator.SetBool("onPressRedButton", false);
                mt.animator.SetBool("onTv0", true);
                monitorImage.animator.SetBool("Tv0ToRedButton", false);
                monitorImage.animator.SetBool("redButtonToTv0", true);
                monitorImage.redButtonScreenPressed = true;
                monitorImage.onTv0Screen = true;
                peopleButton.GetComponent<Renderer>().enabled = true;
                peopleButton.onTv0Screen = true;
                
                for (int i = 0; i < hoverpair.Length; i++){
                    hoverpair[i].screenChanged = true;
                    hoverpair[i].readyToStart = true;
                }

                for (int i = 0; i < headtoken.ts.Length; i++){
                    headtoken.ts[i].GetComponent<Renderer>().enabled = true;
                }

            }
        
            redSelected = false;
        }
        
    }

    // Remember to add the 2D collider to be able to make this method work.
    void OnMouseDown(){ 
        redSelected = true;
    }
}
