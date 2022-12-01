using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim_JCG : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int n = Mathf.RoundToInt(rb.velocity.x);

        
          anim.SetInteger("IntMovement", n); // esto es la animacion de movimiento si se hace un if con el rb y anim y le pones un >0 se queda loco y siempre se sube a dos porque es mayor.
        
    }
}
