using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    public bool returnPressed = false;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("returnPressed", false);

        if (Input.GetMouseButtonDown(0) && returnPressed) {
            animator.SetBool("returnPressed", true);
            returnPressed = false;
        }
    }

  

    // Remember to add the 2D collider to be able to make this method work.
    void OnMouseDown(){ 
        returnPressed = true;
    }
}
