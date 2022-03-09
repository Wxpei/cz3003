using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHandler : MonoBehaviour
{
    public Button loginButton, registerButton, exitButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        loginButton.onClick.AddListener(Login);
        registerButton.onClick.AddListener(Register);
        exitButton.onClick.AddListener(exitGame);
    }

    void Login()
    {
        Debug.Log("Login selected. Load Login Scene.");
    }

    void Register()
    {
        Debug.Log("Register selected. Load Regsister Scene.");
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }
}
