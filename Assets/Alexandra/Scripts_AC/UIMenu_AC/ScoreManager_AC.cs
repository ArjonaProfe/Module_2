using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using TMPro;        //añadimos bibliotecas para la puntuación


public class ScoreManager_AC : MonoBehaviour
{
    private float puntos;       //el float es con decimal
    private TextMeshProUGUI TextMesh;


    private void Start ()
    {
        TextMesh = GetComponent<TextMeshProUGUI>(); //sea igual al texto en pantalla
    }


    private void Update()
    {
        puntos += Time.deltaTime;  //nos sume puntos cada segundo
        TextMesh.text = puntos.ToString("0");   //para quitar decimales le indicamos el 0 como nªentero. Nos modifica el texto según puntuación en pantalla y para que salga en pantalla ponemos el String
    }

}
