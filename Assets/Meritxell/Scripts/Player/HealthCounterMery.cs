using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounterMery : MonoBehaviour     // Script contador con los puntos de salud y vidas. Todos los scripts relacionados toman la informaci�n de este
{
    public static int healthPoints = 5;  // N�mero de puntos de vida
    public static int lives = 3;         // N�mero de vidas

    public static void ResetHealth()     // Funci�n llamada al perder todos los puntos de salud y resetar la fase
    {
        if (healthPoints == 0)   // Si healthPoints llega a zero
        {
            healthPoints = 5;    // Vuelve a setearse a cinco
        }
    }
    
    public static void ResetLives()     // Funci�n llamada al perder todas las vidas y mandar al jugador al Game Over
    {
        if (lives == 0)         // "
        {
            lives = 3;
        }
    }
}