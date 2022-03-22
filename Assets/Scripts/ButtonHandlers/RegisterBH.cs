using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterBH : MonoBehaviour
{
    public Button registerButton, exitButton, backButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        backButton.onClick.AddListener(goBackToLogin);
        registerButton.onClick.AddListener(register);
        exitButton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void register()
    {
        Debug.Log("Single player selected. Load Login.");
    }

    void goBackToLogin()
    {
        SceneManager.LoadScene("Login");
    }

}
