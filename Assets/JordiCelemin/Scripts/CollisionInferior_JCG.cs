using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInferior_JCG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<PlayerMovement_JCG>().SendMessage("Recolocar");  //quiero que busques un cierto objeto de tipo mi personaje Player y cuando lo encuentres mandale un mensaje recolocar
    }
}
