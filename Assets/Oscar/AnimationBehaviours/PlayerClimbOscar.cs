using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbOscar : StateMachineBehaviour
{
    public PlayerControlOscar Player;
    public Rigidbody2D RB2D;
    public float StartGravity, Speed;
    public Vector3 Movement;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = animator.GetComponent<PlayerControlOscar>();
        RB2D = animator.GetComponent<Rigidbody2D>();
        StartGravity = RB2D.gravityScale;
        RB2D.gravityScale = 0;
        RB2D.velocity = new Vector3(0, 0, 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Getting a vector for the movement
        Movement = new Vector3(Player.MoveX, Player.MoveY, 0).normalized;
        //Moving in the chosen direction
        animator.transform.position += new Vector3(Movement.x, Movement.y, 0) * Speed * Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RB2D.gravityScale = StartGravity;
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
