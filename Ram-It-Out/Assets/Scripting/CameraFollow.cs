using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    Vector3 Position;
    Quaternion Rotation;
    float playerRotation;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        Position = Player.transform.position;
        playerRotation = Player.transform.eulerAngles.y;
        Rotation = Quaternion.Euler(0, playerRotation, 0);

        Camera.transform.position = Position + cameraOffset;
        Camera.transform.LookAt(Player.transform);
        Camera.transform.RotateAround(Player.transform.position, Vector3.up, playerRotation);
    }
    
}
