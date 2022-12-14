using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMery : MonoBehaviour
{
    
    public Camera cam1;                     // Se asignar�n las camaras
    public Camera cam2;

    public static Camera mainCam;           // Para usar OnTrigger los valores deben ser est�ticos
    public static Camera secCam;

    public static bool switchedCam;

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;

        mainCam = cam1;
        secCam = cam2;

        switchedCam = false;

    }
    public static void SwitchCamera()
    {
        if (mainCam.enabled == true)
        {
            mainCam.enabled = false;
            secCam.enabled = true;
            switchedCam = true;
            Debug.Log("Change to secCam");
        }
        else 
        {
            secCam.enabled = false;
            mainCam.enabled = true;
            switchedCam = false;
            Debug.Log("Change to mainCam");
        }
        
    }
}
