using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBox : MonoBehaviour
{
    public GameObject JumpingPad;
    public Rigidbody Player;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        thrust = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //if ()
        {
            Player.AddForce(transform.up * thrust, ForceMode.Impulse);
            Player.useGravity = true;
        }
    }
}
