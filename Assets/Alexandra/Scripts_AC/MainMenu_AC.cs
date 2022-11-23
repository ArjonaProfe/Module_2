using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Script para ir de una escena a otra. A�adimos todas las escenas, para que se pueda ir de una a otra.
 * Tenemos el Men� principal con todas las opciones.
 * Tenemos la partida de Juego con la opci�n de Pausa para ir a Menu o a Juego.
 * Tenemos Opciones para cambiar dificultad y volver a Menu.
 * Tenemos Salir del juego.
 * Todas p�blicas para que el jugador pueda interactuar.
 */

public class MainMenu_AC : MonoBehaviour
{
    public void EscenaMenu()                         //p�blica para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("MainMenu_AC");       //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaJuego()                        //p�blica para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Juego_AC");         //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaOpciones()                    //p�blica para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Opciones_AC");     //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaPausa()                     //p�blica para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Pausa_AC");       //el nombre exacto que le hemos puesto a la escena creada
    }
    public void Salir()                           //variable para poder salir del juego
    {
        Application.Quit();                       //Funci�n para salir del juego
    }
}
