using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPoint : MonoBehaviour
{
    public Vector3 positionSpawnPoint;
    public bool triggerSavePoint;
    GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        triggerSavePoint = false;
        var Trigger = Player.GetComponent<PlayerMovement>().triggerTrap;
    }

    // Update is called once per frame
    void Update()
    {
        SavePoint();
    }

    void OnTriggerEnter(Collider savePosition)
    {
        var pointTrigger = savePosition.gameObject.tag;
        if (pointTrigger == "Player")
        {
            triggerSavePoint = true;
        }
    }

    void SavePoint()
    {
        if (triggerSavePoint == true)
        {
            positionSpawnPoint = Player.transform.position;
        }
    }
}
