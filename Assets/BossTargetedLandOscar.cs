using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetedLandOscar : StateMachineBehaviour
{
    public BowserntControlOscar Me;
    public float StartCord, TarCord, Timer, Goal;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StartCord = animator.transform.position.x;
        Me = animator.GetComponent<BowserntControlOscar>();
        TarCord = Me.Target.transform.position.x;
        Timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer += Time.deltaTime/Goal;
        animator.transform.position = new Vector3(Mathf.Lerp(StartCord, TarCord, Timer), animator.transform.position.y, 0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
