using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Damage_AC : MonoBehaviour
{

    [SerializeField] private float pinchoDamage;        //el objeto que nos va a dañar
    [SerializeField] private Health_AC healthController; //referencia al script que carga la vida
    private void OnTriggerEnter2D(Collider2D collision) //cuando suceda la colisión con el trigger
    {
        if (collision.CompareTag("Player"))     //el objeto Player que impacte que suceda lo siguiente
        {
            Damage();                           //que haga daño
        }
    }

    void Damage ()          //Cuando suceda el damage haz lo siguiente
    {
        {
            healthController.playerHealth = healthController.playerHealth - pinchoDamage;   //referencia script health player es herido por X
            healthController.UpdateHealth();                                                //activar script health y cargará la vida
            this.gameObject.SetActive(false);

        } 
    }

}
