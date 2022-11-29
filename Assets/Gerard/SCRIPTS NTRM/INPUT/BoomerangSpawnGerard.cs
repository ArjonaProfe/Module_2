using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSpawnGerard : MonoBehaviour
{

    public Transform BoomerangShoot;
    public Transform waypoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(BoomerangShoot, transform.position, Quaternion.identity);
        }
    }
}
