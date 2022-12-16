using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionMery : MonoBehaviour
{
    public GameObject FadePanel;
    private Animator anim;

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

    public void FadeTransition()
    {
        anim.SetBool("Fading", true);
        fading = true;
        Debug.Log("FadeIn");
        Invoke("SetFadeBack", 0.5f);
        
    }

    public void SetFadeBack()
    {
        anim.SetBool("Fading", false);
        fading = false;
        Debug.Log("FadeOut");
    }
}
