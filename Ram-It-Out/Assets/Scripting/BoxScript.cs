using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 PlayerMovement;
    Vector3 InitialPlace;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get transform position from box position and only get in start
        InitialPlace = Box.GetComponent<Transform>().transform.position;
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
            PlayerMovement = PlayerRB.velocity;
            BoxRB.MovePosition(InitialPlace + PlayerMovement*Time.deltaTime*15f);
        }
        else
        {
            //Box.transform.position = new Vector3(transform.position.z,transform.position.y,transform.position.z);
        }
    }
    
}
