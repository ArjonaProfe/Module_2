using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu_AC : MonoBehaviour
{
    // Start is called before the first frame update
    //bot�n que activa el canvas de Opciones del Main Menu desde el canvas del Main Menu
    public GameObject OpcionesM;         //referenciamos el bot�n que queremos activar cuando lo pulsemos
    public GameObject MenuM;
    public GameObject MenuO;
    public GameObject Opciones;

    // Update is called once per frame
    void Update()
    { //bot�n Opciones del Men�
        if (Input.GetButtonDown("Fire1"))
        {
            OpcionesM.SetActive(true);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            OpcionesM.SetActive(false);
        }
    //bot�n Menu de dentro de Opciones
        if (Input.GetButtonDown("Fire1"))
        {
            Opciones.SetActive(true);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Opciones.SetActive(false);
        }

    }



}
