using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginBH : MonoBehaviour
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
        SceneManager.LoadScene("Main Menu (Student)");
    }

    void Register()
    {
        Debug.Log("Register selected. Load Regsister Scene.");
        SceneManager.LoadScene("Register");
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }
}
