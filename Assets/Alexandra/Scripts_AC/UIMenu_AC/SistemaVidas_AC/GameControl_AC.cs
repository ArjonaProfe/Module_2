using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl_AC : MonoBehaviour     //script sistema de vidas y canvas Game Over
{
    public GameObject Heart_AC1, Heart_AC2, Heart_AC3, gameOver; //objetos en acción
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;                                 //Al inicio, tenemos 3 vidas y están activados los iconos. El texto de Game OVer está inactivado
        Heart_AC1.gameObject.SetActive(true);
        Heart_AC2.gameObject.SetActive(true);
        Heart_AC3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);                          
    }

    // Update is called once per frame
    void Update()                                       //una vez se inicia, durante el juego irá comprobrando la vida
    {
        if (health == 3)                                // si tiene 3 vidas entonces estarán activados los siguientes objetos
        {
           Heart_AC1.gameObject.SetActive(true);       
           Heart_AC2.gameObject.SetActive(true);
           Heart_AC3.gameObject.SetActive(true);
        } 
        else if (health == 2)                           // sino tiene 3, entonces si tiene 2 vidas estarán activados los siguientes objetos
        {
            Heart_AC1.gameObject.SetActive(true);
            Heart_AC2.gameObject.SetActive(true);
            Heart_AC3.gameObject.SetActive(false);
        }
        else if (health == 1)                           // sino tiene 2, entonces si tiene 1 vidas estarán activados los siguientes objetos
        {
            Heart_AC1.gameObject.SetActive(true);
            Heart_AC2.gameObject.SetActive(false);
            Heart_AC3.gameObject.SetActive(false);
        }
        else if (health == 0)                           // sino tiene 1, entonces si tiene 0 vidas estarán activados los siguientes objetos
        {
            Heart_AC1.gameObject.SetActive(false);
            Heart_AC2.gameObject.SetActive(false);
            Heart_AC3.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("buabuabuaa");
        }
    }

}
