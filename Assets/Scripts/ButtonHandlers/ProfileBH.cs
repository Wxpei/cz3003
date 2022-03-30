using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileBH : MonoBehaviour
{
    public Button exitButton, goBackButton, changeUsernameButton, changePasswordButton;

    public Text username, uname, email;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        changeUsernameButton.onClick.AddListener(changeUsername);
        changePasswordButton.onClick.AddListener(changePassword);

        goBackButton.onClick.AddListener(goBackMainMenuStudent);
        exitButton.onClick.AddListener(exitGame);

        username.text = "Username: " + SceneTransfer.username;

        // Get email and naem from database

        uname.text = "Name: " + "temp name";
        email.text = "Email: " + "temp@gmail.com";
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenuStudent()
    {
        SceneManager.LoadScene("Main Menu (Student)");
    }

    void changeUsername()
    {
        Debug.Log("Mathematics World selected. Load Section Scene.");
    }

    void changePassword()
    {
        Debug.Log("Physics World selected. Load Section Scene.");
    }
}
