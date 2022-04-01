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

public class login : MonoBehaviour
{
    // Add the buttons/inputfields/other elements according to your scene
    public Button loginButton, registerButton, exitButton; 
    public InputField Password, Username; 
    // Require coroutine to call IEnumerator functions
    public IEnumerator coroutine; 
    public GameObject textDisplay;
    

    void Start()
    {
        // Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        loginButton.onClick.AddListener(Login);
        registerButton.onClick.AddListener(Register);
        exitButton.onClick.AddListener(exitGame);
    }

    void Login()
    {
        Debug.Log("Login selected. Load Login Scene.");

        // Format to call the functions
        StartCoroutine(login_user(Username.text, Password.text));
        
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

    // Login User
    public IEnumerator login_user(string username, string password) // verify login, password is hashed aka send date to database
   {
       WWWForm form = new WWWForm();
       form.AddField("loginuser",username);
       form.AddField("loginpass",password);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/login.php",form))
       {
           yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text);  // 0 = login fail | 1 = student | 2 = admin
               string result = www.downloadHandler.text;

               switch (result){
                case "1":
                    Debug.Log("Student login");
                    SceneManager.LoadScene("Main Menu (Student)");
                    break;
                case "2":
                    Debug.Log("Teacher login");
                    SceneManager.LoadScene("Main Menu (Teacher)");
                    break; 
                default:
                    Debug.Log("Login fail");
                    textDisplay.GetComponent<Text>().text = "Invalid username or password, please try again.";
                    break;
            }
           }
        //        Debug.Log(result);
        //        if(result.Equals("0"))
        //        {
        //           Debug.Log("fail"); 
        //         //   SceneManager.LoadScene("Login");
        //         textDisplay.GetComponent<Text>().text = "Invalid username or password, please try again.";
        //        }
        //        else if(result.Equals("2"))
        //        {
        //            Debug.Log("Success");
        //            SceneManager.LoadScene("Main Menu (Teacher)");
        //        }
        //        else if(result.Equals("1"))
        //        {
        //         Debug.Log("Student login");
        //         SceneManager.LoadScene("Main Menu (Student)");
        //        }
        //        else{
        //             Debug.Log("fail"); 
        //         //   SceneManager.LoadScene("Login");
        //         textDisplay.GetComponent<Text>().text = "Invalid username or password, please try again.";
        //        }
        //    }
       }
   }
    // Register Student
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
