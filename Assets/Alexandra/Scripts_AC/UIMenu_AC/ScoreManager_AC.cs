using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using TMPro;        //a�adimos bibliotecas para la puntuaci�n


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
        TextMesh.text = puntos.ToString("0");   //para quitar decimales le indicamos el 0 como n�entero. Nos modifica el texto seg�n puntuaci�n en pantalla y para que salga en pantalla ponemos el String
    }

}
