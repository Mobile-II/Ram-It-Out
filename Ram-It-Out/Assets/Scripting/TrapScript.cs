using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject Player;

    bool triggerTrap;
    // Start is called before the first frame update
    void Start()
    {
        triggerTrap = Player.GetComponent<PlayerMovement>().triggerTrap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        var playerDetecter = other.gameObject.tag;
        if (playerDetecter == "Player")
        {
            triggerTrap = true;
        }
    }
}
