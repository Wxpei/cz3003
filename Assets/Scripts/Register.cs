// Import all the following into your individual script file
// P.S : Please see line 287
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class Register : MonoBehaviour
{
    // Add the buttons/inputfields/other elements according to your scene
    public Button Back, registerButton, exitButton; 
    public InputField Name, Username, Email, Password; 
    // Require coroutine to call IEnumerator functions
    public IEnumerator coroutine; 
    

    void Start()
    {
        // Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        Back.onClick.AddListener(goBack);
        registerButton.onClick.AddListener(Register_);
        exitButton.onClick.AddListener(exitGame);
    }

    void goBack()
    {
        Debug.Log("Back");
        SceneManager.LoadScene("Back to Login");      
    }

    void Register_()
    {
        Debug.Log("Register selected. Load Regsister Scene.");
        StartCoroutine(register_student(Username.text, Password.text, Name.text, Email.text));
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    // Login Use
    // Register Student
   public IEnumerator register_student(string username, string password, string name, string email)
    {
       WWWForm form = new WWWForm();
       if(username=="" || password=="" || name=="" || email==""  )
       {
           Debug.Log("Missing Fields");
           yield break;
       }
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
    // Social Media: Share to Twitter
    public void ShareToTW()
    {
        string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
        string descriptionParam = "Hello";
        string appStoreLink = "http://www.YOUROWNAPPLINK.com";
        string nameParameter = "YOUR AWESOME GAME MESSAGE!";
        Application.OpenURL(TWITTER_ADDRESS +"?text=" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Get the Game:\n" + appStoreLink));
    }

}
