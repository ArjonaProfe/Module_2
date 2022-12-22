using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionMery : MonoBehaviour
{
    public Animator anim;

    public bool fading;
    public bool done;

    public GameObject fadePanel;

    public void Start()
    {

        anim.SetBool("Fading", true);

        anim.SetBool("Done", false);

        fading = true;
        done = false;
        Debug.Log("FadeIn");

        Invoke("ResetFading", 0.5f);
    }
    public void FadeTransition()
    {
        anim.SetBool("Fading", true);

        anim.SetBool("Done", false);

        fading = true;
        done = false;
        Debug.Log("FadeIn");

        Invoke("ResetFading", 0.1f);

    }

    void ResetFading()
    {
        anim.SetBool("Fading", false);

        anim.SetBool("Done", true);

        fading = false;
        done = true;
    }

}
