using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class RegisterBH : MonoBehaviour
{
    public Button registerButton, exitButton, backButton;

    public InputField username, uname, email, password;

    public Text output;

    public IEnumerator coroutine;

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

        // Check database for valid details
        string str_username = username.text;
        string str_uname = uname.text;
        string str_email = email.text;
        string str_pw = password.text;
        coroutine = register_student(str_username, str_pw, str_uname, str_email);
        StartCoroutine(coroutine);
        goBackToLogin();
    }

     public IEnumerator register_student(string username, string password, string name, string email)
    {
       WWWForm form = new WWWForm();
       form.AddField("username",username); 
       form.AddField("password",password);
       form.AddField("name",name); 
       form.AddField("email",email);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/register.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text); // The json string returned by the php file
           }
       }
    }

    void goBackToLogin()
    {
        SceneManager.LoadScene("Login");
    }

}



