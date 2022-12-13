using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyMery : MonoBehaviour        // Script para el enemigo que dispara
{
    private Rigidbody2D rb;        // Mantenemos el RB para trackear la posición
    private Animator anim;         // Animaciones
    private SpriteRenderer sr;     // Permite flipear

    public Transform rayOrigin;
    public Transform rayOriginL;

    public Transform target;           // Asignaremos al player (se usa Transform porque estamos cogiendo su posición specificamente)
    public bool isAttacking;           // Bool que usaremos para interactuar con el bool del animator

    private void Start()
    {    
        anim = GetComponent<Animator>();              // Componentes usados
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {   
        Flip();                                       // Se llaman las funciones
        Animation();
        IsAttacking();
    }

    private void Flip()                                              
    {
        if (rb.position.x < target.position.x)               // Si la posición en x del RB es menor a la posición en x del target
        {
            sr.flipX = true;                                 // El sprite se flipea
        }
        else if (rb.position.x > target.position.x)         // Pero si la posición en x del RB es mayor a la posición en x del target
        {
            sr.flipX = false;                               // El sprite no se flipea
        }
    }

    private void Animation()                                       
    {
        anim.SetBool("isAttacking", isAttacking);          // Se setea el bool del animator isAttacking basado en el void isAttacking
    }

    void IsAttacking()                   // No vamos a setear directamente porque tenemos que poner un raycast aqui
    {   
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.right, 10f);
        RaycastHit2D rayL = Physics2D.Raycast(rayOriginL.position, Vector2.left, 10f);
        Debug.DrawRay(rayOriginL.position, Vector2.left, Color.green, 20f, true);

       
        if (rayL.collider != null && (rayL.collider.CompareTag("Player")))
        {
                isAttacking = true;
                
        }
        else if (ray.collider != null && ray.collider.CompareTag("Player"))
        {
                isAttacking = true;
        }
        else
        {
                isAttacking = false;
            
        }

    }
}
