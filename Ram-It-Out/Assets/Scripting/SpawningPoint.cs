using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPoint : MonoBehaviour
{
    public Vector3 positionSpawnPoint;
    public Quaternion rotationSpawnPosition;
    public bool triggerSavePoint;
    bool TriggerTrap;
    public GameObject Trap;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        //Disable savepoint trigger
        triggerSavePoint = false;
        TriggerTrap = Trap.GetComponent<TrapScript>().triggerTrap;
    }

    // Update is called once per frame
    void Update()
    {
        SavePoint();
        if (TriggerTrap == true);
    }
    // Detect collision for player to trigger save point
    void OnTriggerEnter(Collider savePosition)
    {
        var pointTrigger = savePosition.gameObject.tag;
        if (pointTrigger == "Player")
        {
            //Enable save point trigger
            triggerSavePoint = true;
        }
    }
    //Save player location in save point
    void SavePoint()
    {
        if (triggerSavePoint == true)
        {
            positionSpawnPoint = Player.transform.position;
            rotationSpawnPosition = Player.transform.rotation;
            triggerSavePoint = false;
        }
    }
    public void SpawnPosition()
    {
        //Instantiate(Player, positionSpawnPoint, rotationSpawnPosition);
    }
}
