using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerMery : MonoBehaviour        // Script adjunto al componente que muestra los puntos de salud en pantalla
{
    public int healthPoints;

    public Image hearts;
    public Animator anim;
   
    void Start()                                     // Tanto en Start como en update (simplificar?) el componente de texto cogerá el contador de los puntos de salud a mostrar 
    {
        hearts = GetComponent<Image>();
        anim = GetComponent<Animator>();


        anim.SetBool("Five", true); 
        anim.SetBool("Four", false);
        anim.SetBool("Three", false);
        anim.SetBool("Two", false);
        anim.SetBool("One", false);
        anim.SetBool("None", false);
    }

    void Update()
    {

        if(HealthCounterMery.healthPoints == 5)
        {
            anim.SetBool("Five", true);
            anim.SetBool("Four", false);
            anim.SetBool("Three", false);
            anim.SetBool("Two", false);
            anim.SetBool("One", false);
            anim.SetBool("None", false);
        }
        if(HealthCounterMery.healthPoints == 4)
        {
            anim.SetBool("Five", false);
            anim.SetBool("Four", true);
            anim.SetBool("Three", false);
            anim.SetBool("Two", false);
            anim.SetBool("One", false);
            anim.SetBool("None", false);
        }
        if(HealthCounterMery.healthPoints == 3)
        {
            anim.SetBool("Five", false);
            anim.SetBool("Four", false);
            anim.SetBool("Three", true);
            anim.SetBool("Two", false);
            anim.SetBool("One", false);
            anim.SetBool("None", false);
        }
        if(HealthCounterMery.healthPoints == 2)
        {
            anim.SetBool("Five", false);
            anim.SetBool("Four", false);
            anim.SetBool("Three", false);
            anim.SetBool("Two", true);
            anim.SetBool("One", false);
            anim.SetBool("None", false);
        }
        if (HealthCounterMery.healthPoints == 1)
        {
            anim.SetBool("Five", false);
            anim.SetBool("Four", false);
            anim.SetBool("Three", false);
            anim.SetBool("Two", false);
            anim.SetBool("One", true);
            anim.SetBool("None", false);
        }
        if (HealthCounterMery.healthPoints == 0)
        {
            anim.SetBool("Five", false);
            anim.SetBool("Four", false);
            anim.SetBool("Three", false);
            anim.SetBool("Two", false);
            anim.SetBool("One", false);
            anim.SetBool("None", true);
        }
    }
}
