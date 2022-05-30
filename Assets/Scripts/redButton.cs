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

    public bool redSelected = false;
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
        
            redSelected = false;
        }
        
    }

    // Remember to add the 2D collider to be able to make this method work.
    void OnMouseDown(){ 
        redSelected = true;
    }
}
