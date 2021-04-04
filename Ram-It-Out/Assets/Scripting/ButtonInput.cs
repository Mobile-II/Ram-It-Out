using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    public GameObject buttonJump;
    public GameObject buttonPush;
    public GameObject buttonRelease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button buttonJumpActive = buttonJump.GetComponent<Button>();
        Button buttonReleaseActive = buttonRelease.GetComponent<Button>();
        Button buttonPushActive = buttonRelease.GetComponent<Button>();
        

        buttonJumpActive.onClick.AddListener(PlayerPush);
    }
    void PlayerPush()
    {
        bool PushActive = GetComponent<PlayerMovement>().pushingActive;
        if (PushActive == true)
        {
            PushActive = false;
            
        }
    }
}
