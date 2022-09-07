using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusControl : MonoBehaviour
{
    private string[] characters = {"Green", "Blue", "Yellow", "Black", "Pink", "Red"};
    private bool[] alive = {true, true, true, true, true, true};
    public bool eliminationOccurred = false;
    public int characterEliminated = -1;

    public WaypointScript1[] chairs;
    public ConversationHolder conversationHolder;
    public ConversationController converControl;
    

    // Update is called once per frame
    void Update()
    {
        if (eliminationOccurred){
            alive[characterEliminated] = false;
            chairs[characterEliminated].animator.SetBool("gone", true);

            for(int i = 0; i < chairs.Length; i++){
                if(i != characterEliminated){
                    chairs[i].animator.SetBool("closingCapsule", false);
                }
            }
            converControl.conversation = conversationHolder.eliminatedDialogues[characterEliminated];
            converControl.defaultConversation = conversationHolder.eliminatedDialogues[characterEliminated];
            converControl.startConversationTrigger = true;


            eliminationOccurred = false;
            characterEliminated = -1;
        }
    }
}
