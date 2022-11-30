using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoolMery : MonoBehaviour
{
    public Animator anim;
   
     public void DisableHurt()
    {
        anim.SetBool("isHurt", false);
    }
}
