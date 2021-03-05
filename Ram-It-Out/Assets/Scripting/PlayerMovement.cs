using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    bool jumpingLimit;
    float limitTime;
    // Start is called before the first frame update
    void Start()
    {
        limitTime = 5;
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

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            CountDown();
        }
        PlayerJump();
        CountDown();
        Debug.Log(limitTime);
    }
    void PlayerJump()
    {
        if (jumpingLimit == true)
        {
            playerRB.AddForce(transform.up * 50, ForceMode.VelocityChange);
            jumpingLimit = false;
        }
        if (limitTime > 5f)
        {
            jumpingLimit = true;
            limitTime = 0f;
        }
    }
    void CountDown()
    {
        if (jumpingLimit == false)
        {
            limitTime += Time.deltaTime;
        }
    }
}
