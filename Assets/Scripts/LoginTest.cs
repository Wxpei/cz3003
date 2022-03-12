using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginTest : MonoBehaviour
{
    public string userName;
    public string password;
    public GameObject userInput;
    public GameObject passwordInput;
    public GameObject textDisplay; 

    public void printUserPass(){
        userName = userInput.GetComponent<Text>().text;
        password = passwordInput.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Username: " + userName + ", Password: " + password;
    }
}
