using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AceitunaMove_AC : MonoBehaviour
{
    private float horizontal;       // el movimiento de acción será en eje x
    private float speed = 8f;       //variable de velocidad, le ponemos un valor X
    private Rigidbody2D rb;           //mencionamos el Rigidbody



   void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))  //buttonPressed = RIGHT
        {
            transform.position += transform.right * (Time.deltaTime * speed);  // with plus will go left side

        }
        else if (Input.GetKey(KeyCode.A))   //buttonPressed = LEFT
        {
            transform.position -= transform.right * (Time.deltaTime * speed);  // with minus will go left side
        }
       
    }
    
}
