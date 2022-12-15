using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDmgDashOscar : StateMachineBehaviour
{
    public LifeNStatusOscar LifeMan;
    public float Speed;
    public int Damage;
    public Transform CanonPoint1, CanonPoint2;
    public float AtkRadius;
    public LayerMask IsEnemy;
    public Vector3 PushDir;
    public GameObject ParSys;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LifeMan = animator.GetComponent<LifeNStatusOscar>();
        CanonPoint1 = animator.GetComponent<BowserntControlOscar>().CanonPoint1;
        CanonPoint2 = animator.GetComponent<BowserntControlOscar>().CanonPoint2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Running
        animator.transform.position += new Vector3(animator.transform.localScale.x, 0, 0) * Speed * Time.deltaTime;

        //Detecting the targets
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint1.transform.position, AtkRadius, IsEnemy);
        if (EnemiesToDamage.Length > 0)
        {
            for (int i = 0; i < EnemiesToDamage.Length; i++)
            {
                Debug.Log(EnemiesToDamage[i].name);
                if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>() != null && EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
                {
                    EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(Damage, LifeNStatusOscar.DmgType.Strong);
                    EnemiesToDamage[i].transform.position = CanonPoint2.position;
                    if (EnemiesToDamage[i].GetComponent<Rigidbody2D>() != null)
                    {
                        Vector3 Dir = new Vector3(1, 1, 1);
                        if (animator.transform.localScale.x < 0) { Dir.x = -1; }
                        EnemiesToDamage[i].GetComponent<Rigidbody2D>().velocity = Vector3.Scale(PushDir, Dir);
                    }
                }
            }
            Instantiate(ParSys, CanonPoint1.transform.position, Quaternion.identity);
        }

        //Detecting if there is a target
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
