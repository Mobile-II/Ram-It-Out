using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BoxScript : MonoBehaviour
{
    public PlayerMovement movementCount;
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
        BoxRB.isKinematic = true;
    }
    
    void Update()
    {
        pInitialPosition = Player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(isSpeedUp);
        Vector3 playerRotation = Player.transform.eulerAngles;

        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true || isSpeedUp == true)
        {
            //PlayerMovement = PlayerRB.transform.localPosition - pInitialPosition;
            Vector3 PlayerRotationMovement = playerRotation - pInitialRotation;
            //BoxRB.MovePosition(InitialPlace + PlayerMovement);
            
            //BoxRB.rotation = Quaternion.Euler(0,movementCount.dirY,0);
            //Box.transform.SetParent(Player.transform,true);
            //Box.transform.RotateAround(Player.transform.position, Vector3.up, PlayerRotationMovement.y/10);
            BoxRB.isKinematic = false;
        }
        else
        {
            //isKinematic = true;
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
        playerScript.pushingBox = true;
        playerPosition = true;
        isSpeedUp = true;
        
    }
    public void BoxStop()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        playerScript.pushingBox = false;
        playerPosition = false;
    }
    public void DisableMovement()
    {
        isSpeedUp = false;
    }
}
