using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTvG : MonoBehaviour
{
    public bool colliderOn = true;
    public bool screenChanged = false;

    public void OnMouseOver(){
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void OnMouseExit(){
        gameObject.GetComponent<Renderer>().enabled = false;
    }


    void Update()
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
    }

}
