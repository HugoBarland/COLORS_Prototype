using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteButton : MonoBehaviour
{
    public Animator animator;
    bool rouletteButtonPressed = false;

    public HoverPair[] hoverPair = new HoverPair[3];
    public IndividualToken[] individualToken = new IndividualToken[6];
    public MonitorImages monitorImage;
    public PeopleButton peopleButton;
    public Roulette roulette;
    public RouletteNeedle rouletteNeedle;
    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IdleToPressed", false);
        if (hoverPair[0].conversationSeen && hoverPair[1].conversationSeen && hoverPair[2].conversationSeen){
            hoverPair[0].conversationSeen = false;
            hoverPair[1].conversationSeen = false;
            hoverPair[2].conversationSeen = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    
        if (Input.GetMouseButtonDown(0) && rouletteButtonPressed) {
            rouletteButtonPressed = false;
            animator.SetBool("IdleToPressed", true);
        }

        if (animator.GetBool("roulettePressedAnimEnded")){
            animator.SetBool("roulettePressedAnimEnded", false);
            monitorImage.GetComponent<Renderer>().enabled = false;
            peopleButton.GetComponent<Renderer>().enabled = false;
            peopleButton.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            foreach(HoverPair i in hoverPair){
                i.GetComponent<Collider2D>().enabled = false;
            }
            foreach(IndividualToken i in individualToken){
                i.GetComponent<Renderer>().enabled = false;
            }
            roulette.GetComponent<Renderer>().enabled = true;
            roulette.GetComponent<Collider2D>().enabled = true;
            rouletteNeedle.GetComponent<Renderer>().enabled = true;
        }
    }


    // Detects whether the RouletteButton GameObject has been pressed
    void OnMouseDown(){ 
        rouletteButtonPressed = true;
    }
}
