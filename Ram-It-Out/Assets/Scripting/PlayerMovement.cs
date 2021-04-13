using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    //public Rigidbody playerRB;      // Player RigidBody
    public Text textFile;           // Get UI Text
    public bool pushingBox;         // Enable to pull or push
    //bool jumpingLimit;              // Trigger jumping timer
    public bool pushingActive;      // Trigger to when near box
    bool jumpActive;
    int jumpCount;                  // Current jump count
    int jumpMax = 2;                // Maximum jump count
    float limitTime;                // Jumping timer
    public GameObject buttonJump;
    public GameObject buttonPush;
    public GameObject buttonRelease;

    CharacterController charCtrl;
    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0f;
    public float gravityValue = 16.0f;
    public float doubleJumpMultiplier = 1.2f;
    public float moveSpeed = 3.5f;
    
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
        //jumpingLimit = false;
        pushingActive = false;
        pushingBox = false;
        jumpCount = jumpMax;
        limitTime = 0f;

        //Fixing player rigidbody when start the game
        //playerRB = GetComponent<Rigidbody>();
        //playerRB.constraints = RigidbodyConstraints.FreezePositionX |
        //RigidbodyConstraints.FreezeRotationX |
        //RigidbodyConstraints.FreezeRotationY |
        //RigidbodyConstraints.FreezeRotationZ;
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get button function
        //Button buttonJumpActive = buttonJump.GetComponent<Button>();
        //Button buttonReleaseActive = buttonRelease.GetComponent<Button>();
        //Button buttonPushActive = buttonRelease.GetComponent<Button>();

        //Jump Button
        //buttonJumpActive.onClick.AddListener(PlayerJump);
        //CountDown();
        PlayerRespawn();
    }

    void FixedUpdate()
    {
        //Get key input for player
        float y = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 80.0f;
        float z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 355.0f;


        if (charCtrl.isGrounded)
        {
            // Player front and back movement
            moveDirection = new Vector3(0, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            jumpCount = jumpMax;
        }
        moveDirection.y -= gravityValue * Time.deltaTime;

        // Rotate & walking
        transform.Rotate(0, y, 0);
        //transform.Translate(0, 0, z);
        Debug.Log("MoveDirection=" + moveDirection);
        charCtrl.Move(moveDirection);

    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    // Jump reset when touch floor
    //    var objectGround = collision.gameObject.name;
    //    if (objectGround == "Floor")
    //    {
    //        jumpCount = jumpMax;
    //        jumpingLimit = false;
    //    }
    //}
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
            //pushingBox = false;
        }
    }
    // Player Jump
    public void PlayerJump()
    {
        if (jumpCount >= 1)
        {
            //Player will move upward when press the jump button
            //playerRB.AddForce(transform.up * 50, ForceMode.VelocityChange);
            jumpCount -= 1;
            //jumpingLimit = true;

            moveDirection.y = jumpSpeed * doubleJumpMultiplier;
            //Debug.Log("MOveDirection=" + moveDirection);
            charCtrl.Move(moveDirection);
        }
    }

    // Jump Limit cooldown
    //public void CountDown()
    //{
    //    //doing cooldown to prevent player spamming the jump button
    //    if (jumpingLimit == true)
    //    {
    //        limitTime += Time.deltaTime;
    //    }
    //    if (limitTime > 15)
    //    {
    //        jumpCount++;
    //        limitTime = 0;
    //        jumpingLimit = false;
    //    }
    //}

    //Player respawn position if they fall down to trap
    void PlayerRespawn()
    {

    }
}
