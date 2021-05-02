using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button PauseButton;
    public Button PauseMenuButton;
    public Button LevelButton;
    public Button CreditButton;

    ///[SerializeField]
    private bool paused;
    private bool openlevelselection;
    private bool isMute;
    private bool opencredit;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        openlevelselection = false;
        opencredit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!paused)
            {
                paused = true;
                DisplayPauseMenu();
            }
            else
            {
                paused = false;
                HidePauseMenu();
            }
        }

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

        if (Input.GetButtonDown("Credit"))
        {
            if (!opencredit)
            {
                opencredit = true;
                Displaycreditpanel();
            }
            else
            {
                opencredit = false;
                Hidecreditpanel();
            }
        }
    }

    public void DisplayLevelSelection() //for level selection menu to display
    {
       LevelButton.gameObject.SetActive(true);
    }    

    public void HideLevelSelection() //for level selection menu to hide
        {
        LevelButton.gameObject.SetActive(false);
    }

    public void DisplayPauseMenu() //pause menu show
    {
        PauseMenuButton.gameObject.SetActive(true);
    }

    public void HidePauseMenu() //pause menu hide
    {
        PauseMenuButton.gameObject.SetActive(false);
    }


    public void Displaycreditpanel() //credit panel show
    {
        CreditButton.gameObject.SetActive(true);
    }

    public void Hidecreditpanel() //credit panel hide
    {
        CreditButton.gameObject.SetActive(false);
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
        SceneManager.LoadScene(1);
    }

    public void ButtonLevel2()    //quit game
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonLevel3()    //quit game
    {
        SceneManager.LoadScene(3);
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
