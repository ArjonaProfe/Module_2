using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgDashOscar : StateMachineBehaviour
{
    public LifeNStatusOscar LifeMan;
    public EnemyControlOscar Me;
    public float Speed, AtkRadius;
    public int Damage;
    public LayerMask IsEnemy, IsGround;
    public Transform CanonPoint;
    public Vector3 PushDir;
    public bool Running;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LifeMan = animator.GetComponent<LifeNStatusOscar>();
        Me = animator.GetComponent<EnemyControlOscar>();
        CanonPoint = Me.CanonPoint;
        Running = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Running == true)
        {
            //Running
            animator.transform.position += new Vector3(animator.transform.localScale.x, 0, 0) * Speed * Time.deltaTime;

            //Detecting the targets
            Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
            bool Bonk = Physics2D.OverlapCircle(CanonPoint.transform.position, AtkRadius, IsGround);
            if (EnemiesToDamage.Length > 0)
            {
                for (int i = 0; i < EnemiesToDamage.Length; i++)
                {
                    if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
                    {
                        EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(Damage, LifeNStatusOscar.DmgType.Strong);
                        if (EnemiesToDamage[i].GetComponent<Rigidbody2D>() != null)
                        {
                            Vector3 Dir = new Vector3(1, 1, 1);
                            if (animator.transform.localScale.x < 0) { Dir.x = -1; }
                            EnemiesToDamage[i].GetComponent<Rigidbody2D>().velocity = Vector3.Scale(PushDir, Dir);
                        }
                    }
                }
                Running = false;
                Me.ActTimer = 0;
            }
            if(Bonk == true)
            {
                Running = false;
                Me.ActTimer = 0;
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
