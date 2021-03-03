using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 155.0f;

        // Rotate with horizontal key
        transform.Rotate(0, x, 0);
        // Walking with vertical key
        transform.Translate(0, 0, z);
    }
}
