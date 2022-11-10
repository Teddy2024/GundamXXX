using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Teddy
{
    ///<summary>
    ///無敵動畫
    ///</summary>
    public class Invulnerable : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        animator.GetComponent<Teddy.Health>().isInvulnerable = true;
        animator.GetComponent<BoxCollider2D>().enabled = false;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<Teddy.Health>().isInvulnerable = false;
            animator.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

