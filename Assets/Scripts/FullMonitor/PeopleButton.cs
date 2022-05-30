using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleButton : MonoBehaviour
{
    public bool peopleBPressed = false;
    public Animator animator;

    public MonitorImages monitorImage;
    public Monitor miniMonitor;


    // Update is called once per frame
    void Update()

    {
        animator.SetBool("PeopleButtonPressed", false);
        animator.SetBool("CharButtonPressed", false);


        if (Input.GetMouseButtonDown(0) && peopleBPressed) {
            animator.SetBool("PeopleButtonPressed", true);
            animator.SetBool("CharButtonPressed", true);
            peopleBPressed = false;
            monitorImage.peoplePressed = true;
            monitorImage.charactersPressed = true;

            if (miniMonitor.onCharScreen) {
                miniMonitor.onCharScreen = false;
                miniMonitor.screenSwitch = true;
            } else {
                miniMonitor.onCharScreen = true;
                miniMonitor.screenSwitch = true;
            }
        }
    }

  

    // Remember to add the 2D collider to be able to make this method work.
    void OnMouseDown(){ 
        peopleBPressed = true;

    }
}
