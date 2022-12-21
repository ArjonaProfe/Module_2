using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMery : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public GameObject fadePanel;

    public SceneTransitionMery fade;

    void OnTriggerEnter2D(Collider2D other)                                  // Preguntar por axis vertical y porque no funciona
    {
        if (other.CompareTag("Player"))

        {
            Debug.Log("Detect player");
            CameraMery.SwitchCamera();
            PlayerMovementMery.MovePlayer();
            FadingEffect();
        }
    }

    void FadingEffect()
    {
        fade.FadeTransition();
    }
}

