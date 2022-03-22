using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Button loginButton, registerButton, exitButton;
    public InputField userInput;
    public InputField passwordInput;
    public GameObject textDisplay;
    Dictionary<string, string> userDetails = new Dictionary<string, string>
    {
        {"xuanying", "since2001"},
        {"sherelyn912", "since2001"}
    };

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        loginButton.onClick.AddListener(loginDetails);
        registerButton.onClick.AddListener(Register);
        exitButton.onClick.AddListener(exitGame);
    }
    
    public void loginDetails()
    {
        //Get Username from Input then convert it to int
        string userName = userInput.text;
        //Get Password from Input 
        string password = passwordInput.text;

        string foundPassword;
        if (userDetails.TryGetValue(userName, out foundPassword) && (foundPassword == password))
        {
            Debug.Log("User authenticated");
            SceneManager.LoadScene("StudentMainMenu");
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "Invalid username or password";
            Debug.Log("Invalid username or password");
        }
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
