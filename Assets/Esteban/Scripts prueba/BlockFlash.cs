using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFlash : MonoBehaviour
{
    private Animator animBlockFlash;
    // Start is called before the first frame update
    void Start()
    {
        animBlockFlash= GetComponent<Animator>();
        animBlockFlash.SetBool("circleFlash", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Animator GetAnimator()
    {
        return animBlockFlash;
    }

    public void StopBlockFlash()
    {
        animBlockFlash.SetBool("circleFlash", false);
    }
}
