using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_JCG : MonoBehaviour
{
    private float Speed;  //variable velocidad
    public GameObject parent;   //la bala prefab de la scena
    // public CanvasUpdateJordiCelemin cVJCG;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, Speed * Time.deltaTime); //dispara con el transform en x
        Destroy(parent, 1f);// cada cierto segundo destroy
    }
    }