using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Script para ir de una escena a otra. Añadimos todas las escenas, para que se pueda ir de una a otra.
 * Tenemos el Menú principal con todas las opciones.
 * Tenemos la partida de Juego con la opción de Pausa para ir a Menu o a Juego.
 * Tenemos Opciones para cambiar dificultad y volver a Menu.
 * Tenemos Salir del juego.
 * Todas públicas para que el jugador pueda interactuar.
 */

public class MainMenu_AC : MonoBehaviour
{
    public void EscenaMenu()                         //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("MainMenu_AC");       //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaJuego()                        //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Juego_AC");         //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaOpciones()                    //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Opciones_AC");     //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaPausa()                     //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Pausa_AC");       //el nombre exacto que le hemos puesto a la escena creada
    }
    public void Salir()                           //variable para poder salir del juego
    {
        Application.Quit();                       //Función para salir del juego
    }
}
