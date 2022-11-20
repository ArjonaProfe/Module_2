using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Collider2D col;         // Aquí se referenciará el collider 2D del objeto que contenga este script
    private Rigidbody2D rb;         // Aquí se referenciará el rigidbody 2D del objeto que contenga este script

    public float deathJump;         // Aquí se guardará la potencia con la que el personaje saldrá disparado cuando muera 
    public float timer;             // Aquí se guardará el tiempo que pasará desde que se muere hasta que se carga la escena de nuevo
    public string sceneName;        // Aquí se guardará el nombre de la escena que se cargará cuando el personaje muera
    private bool activator = false; // Este bool servirá para avisar al script cuando el personaje muera

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();   // Se asigna a la variable 'col', el componente 'Collider2D' del objeto que tenga este script
        rb = GetComponent<Rigidbody2D>();   // Se asigna a la variable 'rb', el componente 'Rigidbody2D' del objeto que tenga este script
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Cuando un collider 2D impacte contra el objeto que tenga este script
    {
        if (collision.gameObject.tag == "Enemy")           // Se comprueba si ese objeto tiene el tag 'Enemy'
        {
            LifeCounter.lifes = LifeCounter.lifes - 1;     // Se resta una vida a la variable 'lifes' del script 'LifeCounter' 
            rb.velocity = new Vector2(0, deathJump);       // Se le asigna al rigidbody el salto que dará el personaje al morir
            col.enabled = false;                           // Se le desactivará el collider para evitar que siga interactuando con el entorno si está muerto
            activator = true;                              // Se activa el bool para activar el contador de tiempo que cargará la escena de nuevo
        }
    }

    private void Update()
    {
        if (activator == true)                              // Si el bool 'activator' es true
        {
            timer = timer - 1 * Time.deltaTime;             // Se resta 1 unidad cada segundo a la variable 'timer' 
            if (timer < 0)                                  // Si el resultado de la operación es menor que cero
            {
                SceneManager.LoadScene(sceneName);          // Se carga de nuevo la escena guardada en la variable 'sceneName'
            }
        }
    }
}
