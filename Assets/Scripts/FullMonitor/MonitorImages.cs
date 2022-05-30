using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorImages : MonoBehaviour
{
    public Animator animator;

    public bool peoplePressed = false;
    public bool charactersPressed = false;

    public HoverTvG[] hovers;
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("roundToChar", false);
        animator.SetBool("charToRound", false);

        if (peoplePressed) {     
            animator.SetBool("roundToChar", true);

            peoplePressed = false;

            Debug.Log("round to char ");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = false;
            }
        } else if(charactersPressed) {
            animator.SetBool("charToRound", true);

            charactersPressed = false;


            Debug.Log("char to round");
            foreach (HoverTvG hvs in hovers) {
                hvs.screenChanged = true;
                hvs.colliderOn = true;
            }
        }
    }
}
