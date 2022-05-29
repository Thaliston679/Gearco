using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusAnimationControl : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cacto cacto = animator.gameObject.GetComponent<Cacto>();

        if (cacto.GetAggressive())
        {
            animator.SetBool("Aggressive", true);
            animator.SetBool("Peaceful", false);
        }
        else
        {
            animator.SetBool("Aggressive", false);
            animator.SetBool("Peaceful", true);
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    /*
     *
    if (cacto.GetAggressive())
        {
            if (animator.GetBool("Peaceful"))
            {
                animator.SetBool("ToAggressive", true);
            }
            else if (animator.GetBool("ToAggressive"))
            {
                animator.SetBool("Aggressive", true);
            }
        }
        else
        {
            if (animator.GetBool("Aggressive"))
            {
                animator.SetBool("ToPeaceful", true);
            }
            else if (animator.GetBool("ToPeaceful"))
            {
                animator.SetBool("Peaceful", true);
            }
        }
     *
     */

    /*
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cacto cacto = animator.gameObject.GetComponent<Cacto>();

        if (cacto.GetAggressive())
        {
           if (animator.GetBool("ToAggressive"))
           {
                animator.SetBool("ToAggressive", false);
                animator.SetBool("Aggressive", true);
           }
        }
        else
        {
            if (animator.GetBool("ToPeaceful"))
            {
                animator.SetBool("ToPeaceful", false);
                animator.SetBool("Peaceful", true);
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cacto cacto = animator.gameObject.GetComponent<Cacto>();

        if (cacto.GetAggressive())
        {
            if (animator.GetBool("Peaceful"))
            {
                animator.SetBool("Peaceful", false);
                animator.SetBool("ToAggressive", true);
            }
        }
        else
        {
            if (animator.GetBool("Aggressive"))
            {
                animator.SetBool("Aggressive", false);
                animator.SetBool("ToPeaceful", true);
            }
        }
    }
    */
}
