using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualToken : MonoBehaviour
{
    public Animator animator;

    public bool tokenClicked = false;
    public bool otherTokenClicked = false;
    public bool borderAnim = false;
    public bool borderEnd = false;
    public bool secondClick = false;
    public string characterName = "none";
    
    void Update()
    {
        animator.SetBool("IdleToBorder", false);
        animator.SetBool("BorderToIdle", false);

        if (otherTokenClicked){
            //otherTokenClicked = false;
            if (tokenClicked){
                secondClick = true;
                tokenClicked = false;

            }
            if (borderAnim) {
                borderAnim = false;
                animator.SetBool("IdleToBorder", true);
            }
        }

        if(borderEnd){
            borderEnd = false;
            animator.SetBool("BorderToIdle", true);
        }
    }


    void OnMouseDown(){ 
        tokenClicked = true;
    }
}
