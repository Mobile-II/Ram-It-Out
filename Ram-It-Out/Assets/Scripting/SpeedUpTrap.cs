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
    public Rigidbody Boxes;

    // Start is called before the first frame update
    void Start()
    {
        Boxes = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        var targetObject = collision.gameObject.name;
        if (targetObject == "SpeedtoUp")
        {
            Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
            Boxes.useGravity = true;
        }
        if (targetObject == "SpeedtoLeft")
        {
            Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
            Boxes.useGravity = true;
        }
        if (targetObject == "SpeedtoRight")
        {
            Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
            Boxes.useGravity = true;
        }
        if (targetObject == "SpeedtoDown")
        {
            Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
            Boxes.useGravity = true;
        }
    }
}
