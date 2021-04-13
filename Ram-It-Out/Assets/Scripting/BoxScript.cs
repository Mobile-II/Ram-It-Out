using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Vector3 = UnityEngine.Vector3;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 PlayerMovement;
    Vector3 pInitialPosition;
    Vector3 InitialPlace;
    Vector3 pInitialRotation;
    bool playerPosition;
    Rigidbody PlayerRB;
    private Rigidbody BoxRB;
    public bool isSpeedUp;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get transform position from box position and only get in start
        InitialPlace = Box.GetComponent<Transform>().transform.position;
        PlayerRB = Player.GetComponent<Rigidbody>();
        BoxRB = Box.GetComponent<Rigidbody>();
        playerPosition = false;
        isSpeedUp = false;
    }
    
    void Update()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == false)
        {
            BoxRB.isKinematic = true;
        }
        if (isSpeedUp == true)
        {
            playerScript.pushingBox = false;
            BoxRB.transform.position = new Vector3();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerRotation = Player.transform.eulerAngles;

        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true)
        {
            PlayerMovement = PlayerRB.transform.localPosition - pInitialPosition;
            Vector3 PlayerRotationMovement = playerRotation - pInitialRotation;
            BoxRB.MovePosition(InitialPlace + PlayerMovement);
            Box.transform.RotateAround(Player.transform.position, Vector3.up,PlayerRotationMovement.y);
        }
        PlayerInitialPosition();
    }

    void PlayerInitialPosition()
    {
        if (playerPosition == true)
        {
            pInitialPosition = Player.transform.position;
            pInitialRotation = Player.transform.eulerAngles;
            playerPosition = false;
        }
    }
    public void BoxMoveable()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        BoxRB.isKinematic = false;
        playerScript.pushingBox = true;
        playerPosition = true;
    }
    public void BoxStop()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        BoxRB.isKinematic = true;
        playerScript.pushingBox = false;
        playerPosition = false;
    }
}
