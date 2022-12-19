using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;                   //vamos a usar un texto con UI
using UnityEngine.SceneManagement;      //cargar escenas

               


public class Health_AC : MonoBehaviour
{

    public float playerHealth;  //damos nombre
    [SerializeField] private Text healthText;   //especificamos que suceda en el texto del canvas

    // Start is called before the first frame update
    private void Start()
    {
        UpdateHealth();                             //activaremos la acción
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");   //en caso que la vida llegue a 0 en el texto
        if (playerHealth <= 0)
        {
            Debug.Log("Has morio");                         //Da este mensaje y luego carga la escena
        }
    }
    public void EscenaJuego()                        //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("GameOver_AC");         //el nombre exacto que le hemos puesto a la escena creada
    }

}
