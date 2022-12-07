using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLivesMery : MonoBehaviour     // Script que controla que ocurre si el personaje muere
{
    private static Collider2D col;              // Componentes del personaje
    private static Rigidbody2D rb;         
    private static Animator anim;

    public static float deathJump = 10;         // Salto físico al morir

    public int lives;                           // Las vidas se cogen del contador

    public float timer;                         // Tiempo que pasa desde que el personaje muere hasta que la escena carga

    void Start()
    {
        col = GetComponent<Collider2D>();   // Se asigna las variables
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }

    private void Update()        // Update comprueba la salud restante en cada frame
    {
        if (HealthCounterMery.healthPoints == 0)    // Si los puntos de salud llegan a zero se llama ResetLevel
        {
            ResetLevel();                          
        }
        if (HealthCounterMery.lives == 0)          // Si las vidas llegan a zero se llama GameOver
        {
            GameOver();
        }
    }
    public static void Death()                         // cada vez que el personaje muere
    {
        anim.SetBool("isHurt", true);                  // Setea el bool isHurt a verdadero
        rb.velocity = new Vector2(0, deathJump);       // Vector2 que no afecta x pero causará el valor de hurtJump en x sobre el RB
        col.enabled = false;                           // Desactiva el collider del personaje


        HealthCounterMery.lives = HealthCounterMery.lives - 1;     // Se resta una vida  directamente del contador
    }

    void ResetLevel()
    {  
        timer = timer - 1 * Time.deltaTime;             // Se resta 1 unidad cada segundo en tiempo real (deltaTime) al valor asignado a timer
        if (timer < 0)                                  // Si el resultado baja de cero
        {
            SceneManager.LoadScene("sandboxMery");      // Se carga la scena (nota: el nombre puede cambiarse por una public string, por ejemplo SceneName, para diferenciar niveles)
            HealthCounterMery.ResetHealth();            // Se llama la función ResetHealth en el contador
        }
        
    }
    void GameOver()
    {        
        timer = timer - 1 * Time.deltaTime;             // "
        if (timer < 0)                                  
        {
            SceneManager.LoadScene("GameOverMery");          
        }
        
    }
}
