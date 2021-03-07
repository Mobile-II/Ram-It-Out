﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button PauseButton;
    public Button LevelButton;

    ///[SerializeField]
    private bool paused;
    private bool openlevelselection;
    private bool isMute;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        openlevelselection = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LevelSelection"))
        {
            if (!openlevelselection)
            {
                openlevelselection = true;
                DisplayLevelSelection();
            }
            else
            {
                openlevelselection = false;
                HideLevelSelection();
            }
        }
    }

    public void DisplayLevelSelection()
    {
       LevelButton.gameObject.SetActive(true);
    }    

    public void HideLevelSelection()
    {
        LevelButton.gameObject.SetActive(false);
    }

    public void ButtonQuitToMenu()    //quit to menu
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);  //load the scene, the scene(1) is manage from unity.
    }

    public void ButtonLevel1()    //quit game
    {
        SceneManager.LoadScene(3);
    }

    public void ButtonLevel2()    //quit game
    {
        SceneManager.LoadScene(4);
    }

    public void ButtonLevel3()    //quit game
    {
        SceneManager.LoadScene(5);
    }

    public void ButtonQuitGame()    //quit game
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }
    
    public void SoundMute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}
