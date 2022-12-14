using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AceitunaLife_AC : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] int maximoVida;

    private void Start()
    {
        vida = maximoVida;      //vida al inicio
    }
    public void TomarDA�o(int da�o)     //m�todo de recibir da�o
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void curar(int curaci�n)       //m�todo curaci�n. Tiene un tope de vida y se puede curar hasta ese valor. Lo indicamos en Unity
    {
        if ((vida + curaci�n) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curaci�n;
        }
        
    }


}
