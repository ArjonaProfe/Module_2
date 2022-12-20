using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl_AC : MonoBehaviour
{
    public GameObject Heart_AC1, Heart_AC2, Heart_AC3, gameOver; //objetos en acción
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;                                 //tenemos 3 vidas y están activados los iconos. El texto de Game OVer está inactivado
        Heart_AC1.gameObject.SetActive(true);
        Heart_AC2.gameObject.SetActive(true);
        Heart_AC3.gameObject.SetActive(true);
       gameOver.gameObject.SetActive(false);
                      
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
            health = 3;
        switch (health)
        { 
            case 3:
                Heart_AC1.gameObject.SetActive(true);       //en este caso 
                Heart_AC2.gameObject.SetActive(true);
                Heart_AC3.gameObject.SetActive(true);
                break;
            case 2:
                Heart_AC1.gameObject.SetActive(true);
                Heart_AC2.gameObject.SetActive(true);
                Heart_AC3.gameObject.SetActive(false);
                break;
            case 1:
                Heart_AC1.gameObject.SetActive(true);
                Heart_AC2.gameObject.SetActive(false);
                Heart_AC3.gameObject.SetActive(false);
                break;
            case 0:
                Heart_AC1.gameObject.SetActive(false);
                Heart_AC2.gameObject.SetActive(false);
                Heart_AC3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
        
}
