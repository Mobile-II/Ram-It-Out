using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public Vector3 Position;
    Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3 (0, 50, -100);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Camera.transform.position);
    }
    void LateUpdate()
    {
        Position = Player.transform.position;
        
        Camera.transform.position = Position + cameraOffset;
        Camera.transform.rotation = Player.transform.rotation;
    }
}
