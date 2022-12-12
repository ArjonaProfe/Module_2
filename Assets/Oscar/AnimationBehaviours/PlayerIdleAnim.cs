using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleAnim : StateMachineBehaviour
{
    public Rigidbody2D RB2D;
    public Transform GroundPoint;
    public float BigBounce;
    public LayerMask Bouncer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GroundPoint = animator.GetComponent<PlayerControlOscar>().GroundPoint;
        RB2D = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Detecting if it has steppet on a bouncer
        Collider2D[] Bouncy = Physics2D.OverlapCircleAll(GroundPoint.position, 0.3f, Bouncer);
        if (Bouncy.Length != 0 && RB2D.velocity.y >= 0)
        {
            //Jumping after impact
            RB2D.velocity = new Vector2(RB2D.velocity.x, BigBounce);
        }
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
