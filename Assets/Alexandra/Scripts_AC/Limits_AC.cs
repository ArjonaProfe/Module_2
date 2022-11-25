using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits_AC : MonoBehaviour
{
    private Transform theTransfomr; //nos facilitar� el proceso
    public Vector2 Hrange = Vector2.zero;  //nos servir� para marcar los l�mites en horizontal
    public Vector2 Vrange = Vector2.zero;  //nos servir� para marcar los l�mites en vertical

    // Start is called before the first frame update
    void Start()
    {
        theTransfomr = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void LateUpdate()
    {
        theTransfomr.position = new Vector3(                               //usaremos la coma al final de cada eje para facilidad visual
            Mathf.Clamp (transform.position.x, Vrange.x, Vrange.y),      //nos permite establecer un l�mite en el eje (X, en valores negativos, en valores positivos)
            Mathf.Clamp(transform.position.y, Hrange.x, Hrange.y),       //nos permite establecer un l�mite en el eje (Y, en valores negativos, en valores positivos)
            transform.position.z                                       //el eje Z lo dejamos tal y como esta
           );
    }
}
