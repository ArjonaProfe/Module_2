using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn_AC : MonoBehaviour     //script respawn con reset partida sin restar nada
{
    public int Respawn;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)     //cuando colisione con el trigger haz lo siguiente
    {
        if (other.CompareTag("Player"))                 //el objeto con el tag Player recibe la acción indicada a continuación
        {
            SceneManager.LoadScene(Respawn);            //carga la partida, nos sale en Unity un cuadro donde pondremos el núm des escena según build settings en la cual va a hacer respawn
            Debug.Log("Uy");                            //comprobación modo Dios
        }
    }
}
