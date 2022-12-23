using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Enemy3Instancia : MonoBehaviour
{
    [SerializeField] private GameObject enemy3;
    private Enemy3_Attack enemy3_Attack;
    private String norbutName = "Norbut";
    private Transform norbutTransform;

    public void CrearEnemy3()
    {
        Debug.Log("nueva poscición " + transform.position);
        //GameObject enemy3Copy = Instantiate<GameObject>(enemy3);        
        Instantiate(enemy3, transform.position, Quaternion.identity);
        //enemy3_Attack = enemy3.GetComponent<Enemy3_Attack>();
        //enemy3.transform.SetParent(transform);
        //Debug.Log("Encontrado o no " + GameObject.Find(norbutName).transform.name);
        //norbutTransform= GameObject.Find(norbutName).transform;
        //enemy3_Attack.attackToPoint = norbutTransform;
        //transform.SetParent(enemy3.transform);
    }

}
