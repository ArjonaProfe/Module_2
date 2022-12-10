using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsMery : MonoBehaviour          // Script per fer que els objectes flotin al lloc
{
    public float distance;              // Distancia que l'objecte recorre amunt i avall quan flota
    public float speed;                  // Velocitat a la que recorre aquesta distancia
    private float tempVal;               // El valor temporal que serveix per calcular la posició segons on es trobi l'objecte a cada moment
    private Vector2 tempPos;             // Posició temporal a la que l'objecte es moura

    private Vector2 initialPos;          // Posició inicial de l'objecte

    private Rigidbody2D rb;              // Cos físic de l'objecte
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                              // Component del cos físic

        tempVal = transform.position.y;                                // La variació temporal es igual a la posició y 
        initialPos = new Vector2 (rb.position.x, rb.position.y);       // La posició inicial es igual a la posició del rb al començar la escena

        transform.position = initialPos;                               // la posició es coloca a la posició inicial (sino, com el valor x no es toca, per defecte sempre s'enviaría a posició global 0)
    }

    private void Update()
    {
        tempPos.y = tempVal + distance * Mathf.Sin(speed * Time.time);   // La posició temporal de y es igual a la variació temporal (que es la posició actual de y) + la distancia a recorrer, * la funció matemática Sin, que sempre retorna només variable entre 1 o -1, a la velocitat en Time (valor total desde l'inici i no desde l'últim frame com DeltaTime)
        transform.position = new Vector2(initialPos.x, tempPos.y);        // La posició es transforma a una nova posició amb la posició inicial de x y la posició temporal de y, que s'ha calculat abans. Com que la posició temporal sempre cambia basada en la posició actual, y Sin només pot tornar 1 o -1, y tornará a la posició anterior indefinidament
    }
}
