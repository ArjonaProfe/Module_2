using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerAtaque_JCG : MonoBehaviour
{
    public static int scoreValue = 0;    // contador de score de cuando matas a un enemigo
   
     Text scoreMan;
    private void Start()
    {
       scoreMan = GetComponent<Text>();
    }

    private void Update()
    {
       scoreMan.text = "Score:" + scoreValue;     //va subiendo cada vez que matas a un enemigo asignado del Score

    }
}