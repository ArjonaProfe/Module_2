using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChoiceOscar : StateMachineBehaviour
{
    public enum Mode { NumRange, ConsecutiveNum, RandomBoolean }
    public Mode MyMode;
    public int MinNum, MaxNum;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (MyMode)
        {
            case Mode.NumRange:
                animator.SetInteger("Choice", Random.Range(MinNum, MaxNum));
                break;
            case Mode.ConsecutiveNum:
                int CurrNum = animator.GetInteger("Choice");
                CurrNum += 1;
                if(CurrNum > MaxNum) { CurrNum = MinNum; }
                animator.SetInteger("Choice", CurrNum);
                break;
            case Mode.RandomBoolean:
                int Setter = Random.Range(0, 1);
                if(Setter == 0) { animator.SetBool("Choice", false); }
                if(Setter == 1) { animator.SetBool("Choice", true); }
                break;
            default:
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
