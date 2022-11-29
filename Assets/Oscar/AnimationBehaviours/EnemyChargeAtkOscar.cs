using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeAtkOscar : StateMachineBehaviour
{
    public GameObject WarnPropR, WarnPropL, Warning;
    public Transform CanonPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CanonPoint = animator.GetComponent<EnemyControlOscar>().CanonPoint;
        if (animator.transform.localScale.x < 0)
        {
            Warning = Instantiate(WarnPropL, CanonPoint.position, Quaternion.identity);
        }
        else { Warning = Instantiate(WarnPropR, CanonPoint.position, Quaternion.identity); }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Warning != null)
        {
            Destroy(Warning);
        }
    }

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
}
