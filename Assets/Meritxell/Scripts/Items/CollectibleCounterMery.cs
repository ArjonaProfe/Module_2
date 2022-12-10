using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCounterMery : MonoBehaviour   // Script contador para los coleccionables recogidos. Solo se resetearan si se borra la partida
{
    public static int collected = 00;       // El contador va a empezar en zero

    public static void ResetCollectibles()     // Función llamada al perder todas las vidas y mandar al jugador al Game Over
    {
            collected = 00;
    }
}
