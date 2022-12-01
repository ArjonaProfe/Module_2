using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootEnemyMery : MonoBehaviour
{
    private Rigidbody2D rb;        // Mantenemos el RB para colisión
    private Animator anim;         // Animaciones
    private SpriteRenderer sr;     // Permite flipear

    public Transform target;           // Asignaremos al player
    public bool isAttacking;

    private void Start()
    {    
        anim = GetComponent<Animator>();              // Componentes de animación y sprite
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        Flip();                                       // Llama las funciones. TakeDamage no cuenta porque requiere información de otros
        Animation();
        IsAttacking();
    }

    void IsAttacking()
    {
        {
             isAttacking = true;
        }
    }

    void Animation()                                       // si el vector2 no es igual a zero, cambia el valor de moveX y de isMoving, cambiando la animación 
    {
            anim.SetBool("isAttacking", isAttacking);
    }

    void Flip()                                               // Si el target se encuentra a la derecha (mayor que), el sr se flipea; pero si no...
    {
        if (rb.position.x < target.position.x)
        {
            sr.flipX = true;
        }
        else if (rb.position.x > target.position.x)
        {
            sr.flipX = false;
        }
    }
}
