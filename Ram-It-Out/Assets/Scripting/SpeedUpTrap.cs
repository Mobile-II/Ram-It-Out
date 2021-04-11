﻿using System.Collections;
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
    public bool isSpeedUp;
    float timeActivated;
    float timeCount;


    // Start is called before the first frame update
    void Start()
    {
        Boxes = GetComponent<Rigidbody>();
        isSpeedUp = Boxes.GetComponent<BoxScript>().isSpeedUp;
        timeActivated = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeedUp = true)
        {
            timeCount += Time.deltaTime;
        }

        if (timeCount > timeActivated)
        {
            timeCount = 0;
            isSpeedUp = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        var targetObject = collision.gameObject.tag;
        if (targetObject == "Box")
        {
            Boxes.AddForce(transform.up * thrust, ForceMode.Impulse);
            Boxes.useGravity = true;
            isSpeedUp = true;
        }
    }
}
