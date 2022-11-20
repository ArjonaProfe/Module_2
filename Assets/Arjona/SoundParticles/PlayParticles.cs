using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour
{
    public ParticleSystem particles;        //Aqu� se referenciar� el emisor de part�culas (debe estar configurado correctamente)
  
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))    // Si se pulsa la tecla 'A'
        {
            particles.Play();               // Se reproducen las part�culas
        }
    }
}
