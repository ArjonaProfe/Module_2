using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOption_AC : MonoBehaviour
{
    // Start is called before the first frame update
    //botón que activa el canvas de Opciones del Main Menu desde el canvas del Main Menu
    public GameObject Opciones;         //referenciamos el botón que queremos activar cuando lo pulsemos
    public GameObject MenuM;

    // Update is called once per frame
    void Update()
    { //botón Opciones del Menú
        if (Input.GetButtonDown("Fire1"))
        {
            Opciones.SetActive(true);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            MenuM.SetActive(false);
        }
       

    }



}
