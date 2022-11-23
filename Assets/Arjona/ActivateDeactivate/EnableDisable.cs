using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {
            cube.SetActive(true);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            cube.SetActive(false);
        }


    }
}
