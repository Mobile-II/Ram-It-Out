using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;      // Player RigidBody
    public Text textFile;           // Get UI Text
    public bool pushingBox;                // Enable to pull or push
    bool jumpingLimit;              // Trigger jumping timer
    bool pushingActive;             // Trigger to when near box
    int jumpCount;                  // Current jump count
    int jumpMax = 1;                // Maximum jump count
    float limitTime;                // Jumping timer
    
    // Start is called before the first frame update
    void Start()
    {
        jumpingLimit = false;
        pushingActive = false;
        pushingBox = false;
        jumpCount = jumpMax;
        limitTime = 0f;
        playerRB = GetComponent<Rigidbody>();
        playerRB.constraints = RigidbodyConstraints.FreezePositionX | 
                               RigidbodyConstraints.FreezeRotationX | 
                               RigidbodyConstraints.FreezeRotationY | 
                               RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        //Jump Button
        if (textFile.text == "Jump")
        {
            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                PlayerJump();
            }
        }
        if (textFile.text == "Push")
        {
            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                if (pushingActive == true)
                {
                    pushingBox = true;
                }
                else
                {
                    pushingBox = false;
                }

            }
        }
        CountDown();
    }
    void FixedUpdate()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        float z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 155.0f;

        // Rotate & walking
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Jump reset when touch floor
        var objectGround = collision.gameObject.name;
        if (objectGround == "Floor")
        {
            jumpCount = jumpMax;
            jumpingLimit = false;
        }
    }
    void OnTriggerEnter(Collider Boxes)
    {
        // Enable pushing function
        var targetObject = Boxes.gameObject.name;
        if (targetObject == "PushBox")
        {
            textFile.text = "Push";
            pushingActive = true;
        }
    }
    void OnTriggerExit(Collider Boxes)
    {
        //Disable pushing function
        var targetObject = Boxes.gameObject.name;
        if (targetObject == "PushBox")
        {
            textFile.text = "Jump";
            pushingActive = false;
        }
    }
    // Player Jump
    void PlayerJump()
    {
        if (jumpCount >= 1)
        {
            playerRB.AddForce(transform.up * 50, ForceMode.VelocityChange);
            jumpCount -= 1;
            jumpingLimit = true;
        }
    }
    // Jump Limit cooldown
    void CountDown()
    {
        if (jumpingLimit == true)
        {
            limitTime += Time.deltaTime;
        }
        if (limitTime > 15)
        {
            jumpCount++;
            limitTime = 0;
            jumpingLimit = false;
        }
    }
}
