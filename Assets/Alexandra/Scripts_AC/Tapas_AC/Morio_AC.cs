using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morio_AC : MonoBehaviour
{
    public GameObject Pop1;      //en Unity indicaremos el objeto
    public GameObject Pop2;      //en Unity indicaremos el objeto

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);      //cuando choque el objeto que se destruya
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
