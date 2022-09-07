using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatedMessage : MonoBehaviour
{
    public Animator animator;
    public int numCharEliminated = -1;

    public CharacterStatusControl csc;

    void Update()
    {
        animator.SetBool("eliminatedMessageOn", false);

        if (animator.GetBool("readyToEliminate")){
            animator.SetBool("readyToEliminate", false);
            csc.characterEliminated = numCharEliminated;
            numCharEliminated = -1;
            csc.eliminationOccurred = true;
        }
    }
}
