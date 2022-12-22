using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuertaAbierta_JCG : MonoBehaviour
{
    public GameObject Puerta;
    // Start is called before the first frame update
    

    public void AbrirPuerta()
    {

        if(Puerta != null)
        {
            bool IsActive = Puerta.activeSelf; // si le das click en el boton de abrir puerta se quita el sprite
            Puerta.SetActive(!IsActive);
        }
    }

   

}
