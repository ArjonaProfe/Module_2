using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager_JCG : MonoBehaviour
{

    public Text score;         //texto para los puntos
   
    

    public void Update()
    {

        score.text = ScoreManagerAtaque_JCG.scoreValue.ToString();

       
        



    }
    


}
