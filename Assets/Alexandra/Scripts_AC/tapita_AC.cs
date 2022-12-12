using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapita_AC : MonoBehaviour
{
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        transform.position += new Vector3(0, 2 * speed, 0);
        //transform.position = transform.position + new Vector3(0, 2, 0);
    }
}
