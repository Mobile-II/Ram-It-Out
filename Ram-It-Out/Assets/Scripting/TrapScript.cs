using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public bool triggerTrap;
    // Start is called before the first frame update
    void Start()
    {
        triggerTrap = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(triggerTrap);
    }
    void OnTriggerEnter(Collider other)
    {
        var playerDetecter = other.gameObject.tag;
        if (playerDetecter == "Player")
        {
            triggerTrap = true;
        }
    }
}
