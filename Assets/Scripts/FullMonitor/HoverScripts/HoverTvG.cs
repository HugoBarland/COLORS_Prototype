using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTvG : MonoBehaviour
{
    public bool colliderOn = true;

    //screenChanged variable is to be used in MonitorImages or other scripts
    //to notify a screen change from rounds screen.
    public bool screenChanged = false;

    public void OnMouseOver(){
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void OnMouseExit(){
        gameObject.GetComponent<Renderer>().enabled = false;
    }


    public void Update()
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
    }

}
