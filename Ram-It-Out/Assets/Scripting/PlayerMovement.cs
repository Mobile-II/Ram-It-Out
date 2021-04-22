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
<<<<<<< Updated upstream
=======
    public float dirX;
    public float dirY;
    public float dirZ;

    public Vector3 movement;
    public float fwdSpeed = 0.2f;
    public float rotateSpeed = 0.2f;
    public float jumpForce = 3;
    public Animator anim;
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
        //Fixing player rigidbody when start the game
        //playerRB = GetComponent<Rigidbody>();
        //playerRB.constraints = RigidbodyConstraints.FreezePositionX |
        //RigidbodyConstraints.FreezeRotationX |
        //RigidbodyConstraints.FreezeRotationY |
        //RigidbodyConstraints.FreezeRotationZ;
        charCtrl = GetComponent<CharacterController>();
=======
        //playerRB = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();

        //Fixing player rigidbody when start the game
        //playerRB.constraints = RigidbodyConstraints.FreezePositionX |
        //                       RigidbodyConstraints.FreezeRotationX |
        //                       RigidbodyConstraints.FreezeRotationY |
        //                       RigidbodyConstraints.FreezeRotationZ;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        float y = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 80.0f;
        float z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 355.0f;


        if (charCtrl.isGrounded)
=======
        dirY = CrossPlatformInputManager.GetAxis("Horizontal");
        dirZ = CrossPlatformInputManager.GetAxis("Vertical");

        anim.SetFloat("speed", dirZ);

        // Rotate & walking
        //transform.Rotate(0, dirY, 0);
        //transform.Translate(0, 0, dirZ);

        Vector3 m_EulerAngleVelocity;
        m_EulerAngleVelocity = new Vector3(0, dirY*rotateSpeed, 0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity);
        playerRB.MoveRotation(playerRB.rotation * deltaRotation);
       
        movement = new Vector3(0, 0, dirZ*fwdSpeed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement); //Convert movement from local to global coordinate space
        playerRB.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Jump reset when touch floor
        var objectGround = collision.gameObject.tag;
        if (objectGround == "Floor")
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
=======
    //public void OnTriggerEnter(Collider Boxes)
    //{
    //    //Enable the push and release button when near the trigger
    //    // Finding tag for player
    //    var targetObject = Boxes.gameObject.tag;
    //    var playerPoint = Boxes.gameObject.tag;
    //    if (targetObject == "Box")
    //    {
    //        if (pushingBox == false)
    //        {
    //            //Enable push button and disable jump button
    //            buttonJump.SetActive(false);
    //            buttonJump.GetComponent<Image>().enabled = false;
    //            buttonPush.SetActive(true);
    //            buttonPush.GetComponent<Image>().enabled = true;
    //        }
    //        if (pushingBox == true)
    //        {
    //            //Enable release button and disable push and jump button
    //            buttonPush.SetActive(false);
    //            buttonPush.GetComponent<Image>().enabled = false;
    //            buttonRelease.SetActive(true);
    //            buttonRelease.GetComponent<Image>().enabled = false;
    //            buttonJump.SetActive(false);
    //            buttonJump.GetComponent<Image>().enabled = false;
    //        }
    //    }
    //}
    //void OnTriggerExit(Collider Boxes)
    //{
    //    //Disable pushing function
    //    var targetObject = Boxes.gameObject.tag;
    //    if (targetObject == "Box")
    //    {
    //        //Enable jump button when exit trigger range
    //        buttonJump.SetActive(true);
    //        buttonJump.GetComponent<Image>().enabled = true;
    //        buttonRelease.SetActive(false);
    //        buttonRelease.GetComponent<Image>().enabled = false;
    //        buttonPush.SetActive(false);
    //        buttonPush.GetComponent<Image>().enabled = false;
    //        pushingBox = false;
    //    }
    //}
>>>>>>> Stashed changes
    // Player Jump
    public void PlayerJump()
    {
        if (jumpCount >= 1)
        {
            //Player will move upward when press the jump button
<<<<<<< Updated upstream
            //playerRB.AddForce(transform.up * 50, ForceMode.VelocityChange);
=======
            playerRB.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
>>>>>>> Stashed changes
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
