using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionMery : MonoBehaviour
{
    public GameObject FadePanel;
    private static Animator anim;

    public static bool fading;

    public static GameObject fadePanel;

    public void FadeTransition()
    {
        fadePanel.SetActive(true);
        fading = anim.GetBool("Fading");

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
        fadePanel.SetActive(false);
    }
}
