using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPair : MonoBehaviour
{
    public bool colliderOn = true;

    //screenChanged variable is to be used in MonitorImages or other scripts
    //to notify a screen change from rounds screen.
    public bool screenChanged = false;

    //readyToStart becomes true when the red button is pressed to start tv0.
    public bool readyToStart = false;

    public bool hoverPressed = false;
    public bool conversationSeen = false;//meant to be used as a flag that notifies if the conversation was seen.
    public int pairNumber = 0;

    public HeadToken headtoken;
    public ConversationHolder conversationHolder;
    public ConversationController converControl;


    public void OnMouseOver(){
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void OnMouseExit(){
        gameObject.GetComponent<Renderer>().enabled = false;
    }


    public void Update()
    {
        if (screenChanged && readyToStart) {
            screenChanged = false;
            if (colliderOn) {
                //actual collider to false
                gameObject.GetComponent<Collider2D>().enabled = true;
            } else if (!colliderOn){
                //actual collider to true
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && hoverPressed) {
            hoverPressed = false;

            if (pairNumber == 1){
                conversationFinder(headtoken.ts[0].characterName+headtoken.ts[1].characterName);
            } else if (pairNumber == 2){
                conversationFinder(headtoken.ts[2].characterName+headtoken.ts[3].characterName);
            } else if (pairNumber == 3){
                conversationFinder(headtoken.ts[4].characterName+headtoken.ts[5].characterName);
            }

            conversationSeen = true;
        }
    }


    void OnMouseDown(){ 
        hoverPressed = true;
    }

    void conversationFinder(string bothNames){
        Conversation conv = null;
        if(bothNames=="BlackPink" || bothNames=="PinkBlack"){
            conv = conversationHolder.tv0conversations[0];
        } else if(bothNames=="BlueBlack" || bothNames=="BlackBlue"){
            conv = conversationHolder.tv0conversations[1];
        } else if(bothNames=="BluePink" || bothNames=="PinkBlue"){
            conv = conversationHolder.tv0conversations[2];
        } else if(bothNames=="BlueYellow" || bothNames=="YellowBlue"){
            conv = conversationHolder.tv0conversations[3];
        } else if(bothNames=="GreenBlack" || bothNames=="BlackGreen"){
            conv = conversationHolder.tv0conversations[4];
        } else if(bothNames=="GreenBlue" || bothNames=="BlueGreen"){
            conv = conversationHolder.tv0conversations[5];
        } else if(bothNames=="GreenPink" || bothNames=="PinkGreen"){
            conv = conversationHolder.tv0conversations[6];
        } else if(bothNames=="GreenYellow" || bothNames=="YellowGreen"){
            conv = conversationHolder.tv0conversations[7];
        } else if(bothNames=="RedBlack" || bothNames=="BlackRed"){
            conv = conversationHolder.tv0conversations[8];
        } else if(bothNames=="RedBlue" || bothNames=="BlueRed"){
            conv = conversationHolder.tv0conversations[9];
        } else if(bothNames=="RedGreen" || bothNames=="GreenRed"){
            conv = conversationHolder.tv0conversations[10];
        } else if(bothNames=="RedPink" || bothNames=="PinkRed"){
            conv = conversationHolder.tv0conversations[11];
        } else if(bothNames=="RedYellow" || bothNames=="YellowRed"){
            conv = conversationHolder.tv0conversations[12];
        } else if(bothNames=="YellowBlack" || bothNames=="BlackYellow"){
            conv = conversationHolder.tv0conversations[13];
        } else if(bothNames=="YellowPink" || bothNames=="PinkYellow"){
            conv = conversationHolder.tv0conversations[14];
        }

        converControl.conversation = conv;
        converControl.defaultConversation = conv;
        converControl.startConversationTrigger = true;
    }
}
