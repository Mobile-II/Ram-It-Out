using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTrap : MonoBehaviour
{
    
    public float thrust;
    public GameObject Box;
    public Rigidbody Boxes;
    public BoxScript isSpeeding;

    // Start is called before the first frame update
    void Start()
    {
        Boxes = Boxes.GetComponent<Rigidbody>();
        thrust = 10f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        var targetObject = other.gameObject.tag;
        if (targetObject == "Box")
        {
            isSpeeding.DisableMovement();
            Boxes.AddForce(-transform.up * thrust, ForceMode.Impulse);
        }
    }

}
