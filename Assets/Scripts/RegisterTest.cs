using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterTest : MonoBehaviour
{
    public string name;
    public string userName;
    public string email;
    public string password;

    public GameObject nameInput;
    public GameObject userInput;
    public GameObject emailInput;
    public GameObject passwordInput;


    public GameObject credentialsDisplay; 
    public GameObject emailDisplay; 
    public GameObject nameDisplay;

    public void printUserPass(){
        name = nameInput.GetComponent<Text>().text;
        userName = userInput.GetComponent<Text>().text;
        email = emailInput.GetComponent<Text>().text;
        password = passwordInput.GetComponent<Text>().text;

        credentialsDisplay.GetComponent<Text>().text = "Username: " + userName + ", Password: " + password;
    }
}
