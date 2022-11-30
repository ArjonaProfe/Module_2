using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour
{
    public int health;
    public Animator anim;
    public bool isHurt;

    private float timer = 0f;
    private float waitTime = 2f;


    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }
    public void TakeDamage()             // void que llama el int de daño
    {

        Damage.damage = 40;
        health -= Damage.damage;                         // restar el daño a la salud
        HurtAnimation();


        if (health <= 0)                         // si baja de 0, activa void die
        {
            Die();
        }
    }

    void Die()                                  // Destruye el objeto
    {
        Destroy(gameObject);
    }

    void HurtAnimation()
    {
        if (timer < waitTime)
        {
            anim.SetBool("isHurt", false);
        }
        else if (timer > waitTime)
        {
            anim.SetBool("isHurt", true);
        }

    }


}
