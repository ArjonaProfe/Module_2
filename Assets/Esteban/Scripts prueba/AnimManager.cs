using UnityEngine;

public class AnimManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int n = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       //int iValue = (int)n;
       //Debug.Log("int val: " + iValue);


         n = Mathf.RoundToInt(rb.velocity.x);
        anim.SetInteger("transicionCorrer", n);
        Debug.Log("int val: " + n);

    }
}



