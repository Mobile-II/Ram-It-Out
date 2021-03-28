using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    public Vector3 CurrentPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = Box.transform.position;
        
    }
    void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true)
        {
            Box.transform.position = Player.transform.position + CurrentPosition;
        }
        else
        {
            Box.transform.position = new Vector3(transform.position.z,transform.position.y,transform.position.z);
        }
    }
}
