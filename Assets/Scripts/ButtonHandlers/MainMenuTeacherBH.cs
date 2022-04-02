using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuTeacherBH : MonoBehaviour
{
    public Button exitButton, singlePlayerButton, multiPlayerButton, settingsButton, questionBankButton, statisticsButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        singlePlayerButton.onClick.AddListener(singlePlayerMode);
        exitButton.onClick.AddListener(exitGame);
        multiPlayerButton.onClick.AddListener(multiPlayerMode);
        settingsButton.onClick.AddListener(settings);
        questionBankButton.onClick.AddListener(questionBank);
        statisticsButton.onClick.AddListener(statistics);

        SceneTransfer.accountType = "Teacher";
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void singlePlayerMode()
    {
        Debug.Log("Single player selected. Load Single player.");
        SceneManager.LoadScene("AvatarSelection");
    }

    void multiPlayerMode()
    {
        Debug.Log("Multi player selected. Load Multi player.");
        SceneManager.LoadScene("MultiplayerJoinWorld");
    }

    void settings()
    {
        Debug.Log("Settings selected. Load Settings.");
        SceneManager.LoadScene("Setting");
    }

    void questionBank()
    {
        Debug.Log("Question Bank selected. Load Question Bank.");
        SceneManager.LoadScene("Question - Question Bank (Teacher)");
    }

    void statistics()
    {
        Debug.Log("Statistics selected. Load Statistics.");
        SceneManager.LoadScene("Statistics");
    }
}
