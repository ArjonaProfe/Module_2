using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetedLandOscar : StateMachineBehaviour
{
    public BowserntControlOscar Me;
    public Rigidbody2D RB2D;
    public Transform GroundPoint;
    public float StartCord, TarCord, Timer, Goal;
    public LayerMask Poundable;
    public Vector3 PushDir;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StartCord = animator.transform.position.x;
        Me = animator.GetComponent<BowserntControlOscar>();
        RB2D = animator.GetComponent<Rigidbody2D>();
        GroundPoint = Me.GroundPoint;
        TarCord = Me.Target.transform.position.x;
        Timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer += Time.deltaTime/Goal;
        animator.transform.position = new Vector3(Mathf.Lerp(StartCord, TarCord, Timer), animator.transform.position.y, 0);

        //Detecting if it has something to pound bellow
        Collider2D[] Pounded = Physics2D.OverlapCircleAll(GroundPoint.position, 0.8f, Poundable);
        if (Pounded.Length != 0 && RB2D.velocity.y < 0)
        {
            for (int i = 0; i < Pounded.Length; i++)
            {
                Pounded[i].GetComponent<LifeNStatusOscar>().TakeDamage(15, LifeNStatusOscar.DmgType.Weak);
                Pounded[i].GetComponent<Rigidbody2D>().velocity = Vector3.Scale(PushDir, Pounded[i].transform.localScale.normalized);
            }
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
