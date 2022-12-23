using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirCofre : MonoBehaviour
{
    private Animator anim;
    private Transform sueloDestructible;
    private Animator animSueloDestructible;
    
    private ParticleSystem particulas;
    void Start()
    {
        anim = GetComponent<Animator>();        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player detectado");
            anim.SetBool("abrir", true);
            //animSueloDestructible.SetBool("sueloPozo",true);
           // Destroy(sueloDestructible.transform.gameObject, 3);
            Destroy(gameObject, 2);
            PlayerMovement_Es playerMovement_Es = collision.transform.GetComponent<PlayerMovement_Es>();
            playerMovement_Es.Vida = 100f;
            playerMovement_Es.Damage(0f);//esto es para actualizar el progressbar


        }
    }
}
