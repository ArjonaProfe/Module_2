using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManagerMery : MonoBehaviour     // Script adjunto para mostrar los coleccionables en pantalla
{
    public Text collectiblesText;
    public int collected;

    void Start()
    {
        collectiblesText = GetComponent<Text>();

        collectiblesText.text = collected.ToString();
    }

   
    void Update()
    {
        collected = CollectibleCounterMery.collected;
        collectiblesText.text = collected.ToString();
    }
}
