using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundPoundOscar : StateMachineBehaviour
{
    public int XSpeed, YSpeed, MiniBounce, BigBounce;
    public Transform GroundPoint;
    public LayerMask Poundable, Bouncer;
    public int Power;
    public Rigidbody2D RB2D;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GroundPoint = animator.GetComponent<PlayerControlOscar>().GroundPoint;
        RB2D = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Moving downwards, and allowing a small amount of horizontal movement
        animator.transform.position += new Vector3(0, -1, 0) * YSpeed * Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.transform.position += new Vector3(animator.transform.localScale.x, 0, 0) * XSpeed * Time.deltaTime;
        }

        //Detecting if it has something to pound bellow
        Collider2D[] Pounded = Physics2D.OverlapCircleAll(GroundPoint.position, 0.3f, Poundable);
        if(Pounded.Length != 0 && RB2D.velocity.y < 0)
        {
            for (int i = 0; i < Pounded.Length; i++)
            {
                Pounded[i].GetComponent<LifeNStatusOscar>().TakeDamage(Power, true);
            }
            //Jumping after impact
            animator.SetBool("GroundPound", false);
            RB2D.velocity = new Vector2(RB2D.velocity.x, MiniBounce);
        }

        //Detecting if it has steppet on a bouncer
        Collider2D[] Bouncy = Physics2D.OverlapCircleAll(GroundPoint.position, 0.3f, Bouncer);
        if (Bouncy.Length != 0 && RB2D.velocity.y < 0)
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
