using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBH : MonoBehaviour
{
    public Button exitButton, singlePlayerButton, multiPlayerButton, editProfileButton, settingsButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        singlePlayerButton.onClick.AddListener(singlePlayerMode);
        exitButton.onClick.AddListener(exitGame);
        multiPlayerButton.onClick.AddListener(multiPlayerMode);
        editProfileButton.onClick.AddListener(editProfile);
        settingsButton.onClick.AddListener(settings);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void singlePlayerMode()
    {
        Debug.Log("Single player selected. Load Login.");
    }

    void multiPlayerMode()
    {
        Debug.Log("Multi player selected. Load Login.");
    }

    void editProfile()
    {
        Debug.Log("Multi player selected. Load Login.");
    }

    void settings()
    {
        Debug.Log("Multi player selected. Load Login.");
    }

}