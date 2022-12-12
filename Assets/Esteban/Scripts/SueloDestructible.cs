using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloDestructible : MonoBehaviour
{
    //[SerializeField] private GameObject sueloDestructible;
    private Animator animSueloDestructible;
    //private GameObject particulasObject;
    private ParticleSystem particulas;
    void Start()
    {
        animSueloDestructible = GetComponent<Animator>();
        Transform transformParticulas = transform.Find("Particulas");
        particulas = transformParticulas.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player detectado");

            animSueloDestructible.SetBool("sueloPozo", true);
            
            Destroy(gameObject, 2);
            if (particulas)
            {
                particulas.Play();
            }
        }
    }
}
