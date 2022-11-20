using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audio;  // Aqu� se asignar� el componente 'AudioSource'
    public AudioClip sound;     // Aqu� se asignar� el sonido que se quiere reproducir
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();    // Asigna el componente 'AudioSource' del objeto que contenga el script a la variable 'audio�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))        // Si se pulsa la tecla 'F'
        {
            audio.PlayOneShot(sound);        // 'audio' reproducir� el sonido 'sound' 
        }
    }
}
