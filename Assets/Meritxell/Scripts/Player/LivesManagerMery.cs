using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManagerMery : MonoBehaviour     // Script adjunto al componente que muestra las vidas en pantalla
{
    public Text livesText;     // Componentes
    public int lives;

    void Start()                                 // Tanto en Start como en update (simplificar?) el componente de texto cogerá el contador de las vidas a mostrar 
    {
        livesText = GetComponent<Text>();        

        livesText.text = lives.ToString();       
    }

    void Update()
    {
        lives = HealthCounterMery.lives;
        livesText.text = lives.ToString();
    }
}
