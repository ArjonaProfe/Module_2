using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatformOscar : MonoBehaviour
{
    public SpriteRenderer MyLook;
    public BoxCollider2D MyBox, MyDetect;
    public Animator Anim;
    public bool Touched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Touched == false)
        {
            Anim.SetTrigger("Break");
            Touched = true;
        }
    }

    public void Unmake()
    {
        MyLook.enabled = false;
        MyBox.enabled = false;
        MyDetect.enabled = false;
    }

    public void Remake()
    {
        Touched = false;
        MyLook.enabled = true;
        MyBox.enabled = true;
        MyDetect.enabled = true;
        Anim.SetTrigger("Restore");
    }
}
