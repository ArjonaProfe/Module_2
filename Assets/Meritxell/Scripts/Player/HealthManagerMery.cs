using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerMery : MonoBehaviour        // Script adjunto al componente que muestra los puntos de salud en pantalla
{
    public Text healthText;      // Componentes
    public int healthPoints;
   
    void Start()                                     // Tanto en Start como en update (simplificar?) el componente de texto cogerá el contador de los puntos de salud a mostrar 
    {
        healthText = GetComponent<Text>();

        healthText.text = healthPoints.ToString();
    }

    void Update()
    {
        healthPoints = HealthCounterMery.healthPoints;
        healthText.text = healthPoints.ToString();
    }
}
