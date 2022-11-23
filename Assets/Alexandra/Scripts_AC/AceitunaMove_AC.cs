using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AceitunaMove_AC : MonoBehaviour
{

    public GameObject Pop;
    private float Speed = 2f;
    private Rigidbody2D Aceituna;

    // Start is called before the first frame update
    void Start()
    {
        Aceituna = GetComponent<Rigidbody2D>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        float SpeedX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector2.(SpeedX, 0f) * Time.deltaTime;
       
    }
    */
}
