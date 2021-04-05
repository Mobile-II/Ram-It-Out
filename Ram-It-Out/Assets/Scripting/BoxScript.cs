using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 PlayerMovement;
    Vector3 pInitialPosition;
    Vector3 InitialPlace;
    bool playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get transform position from box position and only get in start
        InitialPlace = Box.GetComponent<Transform>().transform.position;
        playerPosition = false;
    }


    void Update()
    
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody PlayerRB = Player.GetComponent<Rigidbody>();
        Rigidbody BoxRB = Box.GetComponent<Rigidbody>();

        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true)
        {
            
            PlayerMovement = PlayerRB.transform.localPosition - pInitialPosition;
            BoxRB.MovePosition(InitialPlace + PlayerMovement);
        }
        PlayerInitialPosition();
    }

    void PlayerInitialPosition()
    {
        if (playerPosition == true)
        {
            pInitialPosition = Player.transform.position;
            playerPosition = false;
        }
    }
    public void BoxMoveable()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        Rigidbody BoxRB = Box.GetComponent<Rigidbody>();
        BoxRB.isKinematic = false;
        playerScript.pushingBox = true;
        playerPosition = true;
    }
    public void BoxStop()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        playerScript.pushingBox = false;
    }
}
