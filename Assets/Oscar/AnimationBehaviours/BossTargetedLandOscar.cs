using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetedLandOscar : StateMachineBehaviour
{
    public BowserntControlOscar Me;
    public Rigidbody2D RB2D;
    public Transform GroundPoint;
    public float StartCord, TarCord, Timer, Goal, Recoloc;
    public LayerMask Poundable;
    public Vector3 PushDir;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StartCord = animator.transform.position.x;
        Me = animator.GetComponent<BowserntControlOscar>();
        RB2D = animator.GetComponent<Rigidbody2D>();
        GroundPoint = Me.GroundPoint;
        Transform TarTrans = null;
        float MinDist = Mathf.Infinity;
        for (int i = 0; i < Me.BreakPlats.Count; i++)
        {
            float Dist = Vector3.Distance(Me.BreakPlats[i].transform.position, Me.Target.transform.position);
            if (Dist < MinDist)
            {
                TarTrans = Me.BreakPlats[i];
                MinDist = Dist;
            }
        }
        TarCord = TarTrans.position.x;
        Timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Lerps towards the targeted X position
        Timer += Time.deltaTime/Goal;
        animator.transform.position = new Vector3(Mathf.Lerp(StartCord, TarCord, Timer), animator.transform.position.y, 0);

        //Detecting if it has something to pound bellow
        Collider2D[] Pounded = Physics2D.OverlapCircleAll(GroundPoint.position, 0.8f, Poundable);
        if (Pounded.Length != 0 && RB2D.velocity.y < 0)
        {
            for (int i = 0; i < Pounded.Length; i++)
            {
                int Direction = 1;
                if (animator.transform.position.x > Pounded[i].transform.position.x) { Direction = -1; }
                Pounded[i].GetComponent<LifeNStatusOscar>().TakeDamage(15, LifeNStatusOscar.DmgType.Weak);
                Pounded[i].transform.position += new Vector3(Recoloc * Direction, 0, 0);
                Pounded[i].GetComponent<Rigidbody2D>().velocity = new Vector3(PushDir.x * Direction, PushDir.y, 0);
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
