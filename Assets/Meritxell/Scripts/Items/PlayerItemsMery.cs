using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsMery : MonoBehaviour          // Script per fer que els objectes flotin al lloc
{
    public float distance;              // Distancia que l'objecte recorre amunt i avall quan flota
    public float speed;                  // Velocitat a la que recorre aquesta distancia
    private float tempVal;               // El valor temporal que serveix per calcular la posici� segons on es trobi l'objecte a cada moment
    private Vector2 tempPos;             // Posici� temporal a la que l'objecte es moura

    private Vector2 initialPos;          // Posici� inicial de l'objecte

    private Rigidbody2D rb;              // Cos f�sic de l'objecte
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                              // Component del cos f�sic

        tempVal = transform.position.y;                                // La variaci� temporal es igual a la posici� y 
        initialPos = new Vector2 (rb.position.x, rb.position.y);       // La posici� inicial es igual a la posici� del rb al comen�ar la escena

        transform.position = initialPos;                               // la posici� es coloca a la posici� inicial (sino, com el valor x no es toca, per defecte sempre s'enviar�a a posici� global 0)
    }

    private void Update()
    {
        tempPos.y = tempVal + distance * Mathf.Sin(speed * Time.time);   // La posici� temporal de y es igual a la variaci� temporal (que es la posici� actual de y) + la distancia a recorrer, * la funci� matem�tica Sin, que sempre retorna nom�s variable entre 1 o -1, a la velocitat en Time (valor total desde l'inici i no desde l'�ltim frame com DeltaTime)
        transform.position = new Vector2(initialPos.x, tempPos.y);        // La posici� es transforma a una nova posici� amb la posici� inicial de x y la posici� temporal de y, que s'ha calculat abans. Com que la posici� temporal sempre cambia basada en la posici� actual, y Sin nom�s pot tornar 1 o -1, y tornar� a la posici� anterior indefinidament
    }
}
