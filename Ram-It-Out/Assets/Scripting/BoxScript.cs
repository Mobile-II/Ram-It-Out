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
    Rigidbody PlayerRB;
    private Rigidbody BoxRB;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get transform position from box position and only get in start
        InitialPlace = Box.GetComponent<Transform>().transform.position;
        PlayerRB = Player.GetComponent<Rigidbody>();
        BoxRB = Box.GetComponent<Rigidbody>();
        playerPosition = false;
    }
    
    void Update()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == false)
        {
            BoxRB.isKinematic = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerRotation = Player.transform.eulerAngles.y;

        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true)
        {
            PlayerMovement = PlayerRB.transform.localPosition - pInitialPosition;
            BoxRB.MovePosition(InitialPlace + PlayerMovement);
            Box.transform.RotateAround(Player.transform.position, Vector3.up, playerRotation*0.5f);
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
