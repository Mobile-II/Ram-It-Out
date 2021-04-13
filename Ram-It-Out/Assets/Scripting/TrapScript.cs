using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public bool triggerTrap;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        triggerTrap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerTrap == true)
        {
            PlayerLose();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        var playerDetecter = other.gameObject.tag;
        if (playerDetecter == "Player")
        {
            triggerTrap = true;
        }
    }
    void PlayerLose()
    {
        Destroy(Player);
    }
}
