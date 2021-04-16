using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;      // Player RigidBody
    public Text textFile;           // Get UI Text
    public bool pushingBox;         // Enable to pull or push
    bool jumpingLimit;              // Trigger jumping timer
    public bool pushingActive;      // Trigger to when near box
    bool jumpActive;
    int jumpCount;                  // Current jump count
    int jumpMax = 1;                // Maximum jump count
    float limitTime;                // Jumping timer
    public GameObject buttonJump;
    public GameObject buttonPush;
    public GameObject buttonRelease;
    public float dirX;
    public float dirY;
    public float dirZ;
    

    // Start is called before the first frame update
    void Start()
    {
        //Setting up which button will show up
        buttonJump.SetActive(true);
        buttonJump.GetComponent<Image>().enabled = true;
        buttonRelease.SetActive(false);
        buttonRelease.GetComponent<Image>().enabled = false;
        buttonPush.SetActive(false);
        buttonPush.GetComponent<Image>().enabled = false;
        
        //Disable all the boolean for pushing box
        //Enable the jump action in initial
        jumpingLimit = false;
        pushingActive = false;
        pushingBox = false;
        jumpCount = jumpMax;
        limitTime = 0f;
        
        //Fixing player rigidbody when start the game
        playerRB = GetComponent<Rigidbody>();
        playerRB.constraints = RigidbodyConstraints.FreezePositionX |
                               RigidbodyConstraints.FreezeRotationX |
                               RigidbodyConstraints.FreezeRotationY |
                               RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        //Get button function
        Button buttonJumpActive = buttonJump.GetComponent<Button>();
        Button buttonReleaseActive = buttonRelease.GetComponent<Button>();
        Button buttonPushActive = buttonRelease.GetComponent<Button>();
        
        //Jump Button
        buttonJumpActive.onClick.AddListener(PlayerJump);
        CountDown();
        PlayerRespawn();
        Debug.Log(dirZ);
    }
    void FixedUpdate()
    {
        //Get key input for player
        dirY = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 80.0f;
        dirZ = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 355.0f;

        // Rotate & walking
        transform.Rotate(0, dirY, 0);
        transform.Translate(0, 0, dirZ);
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
    public void OnTriggerEnter(Collider Boxes)
    {
        //Enable the push and release button when near the trigger
        // Finding tag for player
        var targetObject = Boxes.gameObject.tag;
        var playerPoint = Boxes.gameObject.tag;
        if (targetObject == "Box")
        {
            if (pushingBox == false)
            {
                //Enable push button and disable jump button
                buttonJump.SetActive(false);
                buttonJump.GetComponent<Image>().enabled = false;
                buttonPush.SetActive(true);
                buttonPush.GetComponent<Image>().enabled = true;
            }
            if (pushingBox == true)
            {
                //Enable release button and disable push and jump button
                buttonPush.SetActive(false);
                buttonPush.GetComponent<Image>().enabled = false;
                buttonRelease.SetActive(true);
                buttonRelease.GetComponent<Image>().enabled = false;
                buttonJump.SetActive(false);
                buttonJump.GetComponent<Image>().enabled = false;
            }
        }
    }
    void OnTriggerExit(Collider Boxes)
    {
        //Disable pushing function
        var targetObject = Boxes.gameObject.tag;
        if (targetObject == "Box")
        {
            //Enable jump button when exit trigger range
            buttonJump.SetActive(true);
            buttonJump.GetComponent<Image>().enabled = true;
            buttonRelease.SetActive(false);
            buttonRelease.GetComponent<Image>().enabled = false;
            buttonPush.SetActive(false);
            buttonPush.GetComponent<Image>().enabled = false;
            pushingBox = false;
        }
    }
    // Player Jump
    public void PlayerJump()
    {
        if (jumpCount >= 1)
        {
            //Player will move upward when press the jump button
            playerRB.AddForce(transform.up * 50, ForceMode.VelocityChange);
            jumpCount -= 1;
            jumpingLimit = true;
        }
    }
    // Jump Limit cooldown
    void CountDown()
    {
        //Doing cooldown to prevent player spamming the jump button
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
    //Player respawn position if they fall down to trap
    void PlayerRespawn()
    {
        //Vector3 RespawnPosition = GetComponent<SpawningPoint>().positionSpawnPoint;

    }
}
