using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AceitunaMove_AC : MonoBehaviour
{
    private float speed = 8f;       //variable de velocidad, le ponemos un valor X

    void Update()
    {
        if (Input.GetKey(KeyCode.D))  //buttonPressed = RIGHT
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);  // with plus will go left side

        }
        else if (Input.GetKey(KeyCode.A))   //buttonPressed = LEFT
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);   // with minus will go left side
        }
       
    }
    
}
