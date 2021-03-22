using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 FixingPosition;
    bool EnableFixing;
    
    // Start is called before the first frame update
    void Start()
    {
        FixingPosition = new Vector3(0, 0, 100);
        EnableFixing = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var playerScript = Player.GetComponent<PlayerMovement>();
        if (playerScript.pushingBox == true)
        {
            EnableFixing = true;
            if (EnableFixing == true)
            {
                Box.transform.position = Player.transform.position + FixingPosition;
                EnableFixing = false;
            }
            else
            {
                Box.transform.position = Player.transform.position;
            }
        }
    }
}
