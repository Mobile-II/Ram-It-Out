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
    Vector3 cameraOffset;
    Quaternion cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3 (0, 100, -400);
        //cameraRotation = 
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        Position = Player.transform.position;
        playerRotation = Player.transform.eulerAngles.y;
        Rotation = Quaternion.Euler(0, playerRotation, 0);
        
        Camera.transform.position = Position + cameraOffset;
        Camera.transform.LookAt(Player.transform);
        //Camera.transform.rotation = Rotation;
    }
}
