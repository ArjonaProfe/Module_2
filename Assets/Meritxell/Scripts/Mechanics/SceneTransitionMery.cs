using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionMery : MonoBehaviour
{
    public GameObject FadePanel;
    private static Animator anim;

    public static bool fading;
    public static bool done;

    void Start()
    {
        anim = GetComponent<Animator>();

        fading = anim.GetBool("Fading");
        done = anim.GetBool("Done");

        fading = false;
        done = true;

        
    }
    public static void FadeTransition()
    {
        var variable = new SceneTransitionMery();

        fading = true;
        done = false;
        variable.Invoke("SetBoolBack", 1f);
    }

    void SetBoolBack()
    {
        anim.SetBool("Fading", false);
        anim.SetBool("Done", true); 
    }
}
