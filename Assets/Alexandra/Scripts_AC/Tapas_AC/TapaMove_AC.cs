using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaMove_AC : MonoBehaviour
{
    public float speed;         //velocidad del objeto que indicaremos en Unity

    // Start is called before the first frame update

    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;  //el objeto se va a mover en el eje y a la velocidad indicada según el tiempo de cada PC

    }
}
