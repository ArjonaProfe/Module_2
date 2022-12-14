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
    public void TomarDAño(int daño)     //método de recibir daño
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void curar(int curación)       //método curación. Tiene un tope de vida y se puede curar hasta ese valor. Lo indicamos en Unity
    {
        if ((vida + curación) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curación;
        }
        
    }


}
