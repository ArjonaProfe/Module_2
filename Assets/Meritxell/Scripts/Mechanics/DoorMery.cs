using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMery : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Fire2"))

        {
            Debug.Log("Detect player");
            CameraMery.SwitchCamera();
            PlayerMovementMery.MovePlayer();
        }
    }
}

