using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 PlayerMovement;
    
    // Start is called before the first frame update
    void Start()
    {       
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
            BoxRB.MovePosition(Box.transform.position + PlayerMovement*Time.deltaTime*15f);
        }
        else
        {
            //Box.transform.position = new Vector3(transform.position.z,transform.position.y,transform.position.z);
        }
    }
}
