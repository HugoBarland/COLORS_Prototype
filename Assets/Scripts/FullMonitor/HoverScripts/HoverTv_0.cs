using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTv_0 : HoverTvG
{
    public bool tv0Pressed = false;
    public MonitorImages monitorImage;
    public PeopleButton peopleButton;

    new void Update()
    {
        if (screenChanged) {
            if (colliderOn) {
                screenChanged = false;
                //actual collider to false
                gameObject.GetComponent<Collider2D>().enabled = true;
            } else if (!colliderOn){
                screenChanged = false;
                //actual collider to true
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(0) && tv0Pressed) {
            tv0Pressed = false;

            monitorImage.tv0Pressed = true;
            peopleButton.tv0Pressed = true;

        }

    }

    
    void OnMouseDown(){ 
        tv0Pressed = true;
    }
}
