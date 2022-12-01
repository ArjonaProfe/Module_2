using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager_JCG : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Player;
    public float yOffset = 1f;

    void Update()
    {
        Vector3 newPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

}