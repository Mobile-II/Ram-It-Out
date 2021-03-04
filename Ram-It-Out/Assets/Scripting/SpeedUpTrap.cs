using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTrap : MonoBehaviour
{
    public GameObject SpeedLeft;
    public GameObject SpeedRight;
    public GameObject SpeedTop;
    public GameObject SpeedBottom;
    public float thrust;
    public List<Rigidbody> Boxes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //if()
        {
            //Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
           // Player.useGravity = true;
        }
    }
}
