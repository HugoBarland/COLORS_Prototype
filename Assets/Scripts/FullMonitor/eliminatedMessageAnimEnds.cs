using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminatedMessageAnimEnds : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Camera.main.transform.Translate(0,2.78f,0);
        animator.SetBool("readyToEliminate", true);
    }


}
