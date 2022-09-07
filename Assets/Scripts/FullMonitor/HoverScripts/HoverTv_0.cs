using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTv_0 : HoverTvG
{
    public bool tv0Pressed = false;
    public MonitorImages monitorImage;
    public Monitor miniMonitor;
    public PeopleButton peopleButton;
    public HoverPair[] hoverpair;

    new void Update()
    {
        if (screenChanged) {
            screenChanged = false;
            if (colliderOn) {
                //actual collider to false
                gameObject.GetComponent<Collider2D>().enabled = true;
            } else if (!colliderOn){
                //actual collider to true
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(0) && tv0Pressed) {
            tv0Pressed = false;

            monitorImage.tv0Pressed = true;
            peopleButton.tv0Pressed = true;
            miniMonitor.animator.SetBool("onRoundScreen", false);
            miniMonitor.animator.SetBool("onTv0", true);
            for (int i = 0; i < hoverpair.Length; i++){
                hoverpair[i].screenChanged = true;
                hoverpair[i].colliderOn = true;
            }

        }

    }

    
    void OnMouseDown(){ 
        tv0Pressed = true;
    }
}
