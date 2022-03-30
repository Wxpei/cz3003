using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class AvatarBH : MonoBehaviour
{
    public Button avatarTimeButton, avatarLifeButton, exitButton, goBackButton;

    // Start is called before the first frame update
    void Start()
    {
        avatarTimeButton.onClick.AddListener(avatarTime);
        avatarLifeButton.onClick.AddListener(avatarLife);

        goBackButton.onClick.AddListener(goBackMainMenu);
        exitButton.onClick.AddListener(exitGame);

    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenu()
    {
        SceneManager.LoadScene("Main Menu (" + SceneTransfer.accountType + ")");
    }

    void avatarTime()
    {
        SceneTransfer.avatarTime = true;
        SceneTransfer.avatarLife = false;

        SceneManager.LoadScene("World Selection");
    }

    void avatarLife()
    {
        SceneTransfer.avatarTime = false;
        SceneTransfer.avatarLife = true;

        SceneManager.LoadScene("World Selection");
    }

}
