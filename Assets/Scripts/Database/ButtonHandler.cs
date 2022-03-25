// Import the following into your individual script file
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class ButtonHandler : MonoBehaviour
{
    // Add the buttons/inputfields/other elements according to your scene
    public Button loginButton, registerButton, exitButton; 
    public InputField Password, Username; 
    // Require coroutine to call IEnumerator functions
    public IEnumerator coroutine; 
    

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
        coroutine = login_user(Username.text, Password.text);
        StartCoroutine(coroutine);

        Debug.Log("End");
        
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
               Debug.Log(www.downloadHandler.text);  
               Register();
           }
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

    // Retrieve Questions
       public IEnumerator get_questions(string topic, string difficulty)
   {
       WWWForm form = new WWWForm();
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/fetch_questions.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text); // The json string returned by the php file
               string jsonArray = www.downloadHandler.text;
               Debug.Log(jsonArray);
               questionData_list questionlist = JsonUtility.FromJson<questionData_list>("{\"question_data\": " + jsonArray + "}");
			   //As there maybe multiple outputs, we have to store the results as a list
               // Select the first line from the collection, and print its dialogue:
               for(int i =0; i<2;i++)
               {
               Debug.Log("User 1  = " + questionlist.question_data[i].question_description);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_1);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_2);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_3);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_4);
               Debug.Log("User 1  = " + questionlist.question_data[i].correct_answer);
			   Debug.Log("User 1  = " + questionlist.question_data[i].topic);
			   Debug.Log("User 1  = " + questionlist.question_data[i].difficulty);
			   Debug.Log("User 1  = " + questionlist.question_data[i].assignment_id);
                }
           }
       }
   }

   // Retrieve Leaderboard
    public IEnumerator get_leaderboard(string topic, string difficulty)
    {
       WWWForm form = new WWWForm();
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/fetch_leaderboard.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text); // The json string returned by the php file
               string jsonArray = www.downloadHandler.text;
               Debug.Log(jsonArray);
               leaderboard_list leaderboardList = JsonUtility.FromJson<leaderboard_list>("{\"leaderboard_data\": " + jsonArray + "}");
			   //As there maybe multiple outputs, we have to store the results as a list
               // Select the first line from the collection, and print its dialogue:
               for(int i =0; i<2;i++)
               {
               Debug.Log("User 1  = " + leaderboardList.leaderboard_data[i].username);
               Debug.Log("User 1  = " + leaderboardList.leaderboard_data[i].score);
               Debug.Log("User 1  = " + leaderboardList.leaderboard_data[i].topic);
               Debug.Log("User 1  = " + leaderboardList.leaderboard_data[i].difficulty);
                }
           }
       }
    }

    // Add new entry to leaderboard
    public IEnumerator insert_leaderboard(string username, int score, string topic, string difficulty)
    {
       WWWForm form = new WWWForm();
       form.AddField("username",username); 
       form.AddField("score",score);
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/insert_leaderboard.php",form)) // sending inputs to be queried, will be done by php
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

    // Add new question into question bank
    public IEnumerator insert_question(string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty)
    {
       WWWForm form = new WWWForm();
       form.AddField("question_description",question_description);
       form.AddField("answer_1",answer_1);
       form.AddField("answer_2",answer_2);
       form.AddField("answer_3",answer_3);
       form.AddField("answer_4",answer_4);
       form.AddField("correct_answer",correct_answer);
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/insert_question.php",form)) // sending inputs to be queried, will be done by php
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

    // Add new question into custom assignment (custom world)
    public IEnumerator insert_assignment_question(string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty, string assignment_id)
    {
       WWWForm form = new WWWForm();
       form.AddField("question_description",question_description);
       form.AddField("answer_1",answer_1);
       form.AddField("answer_2",answer_2);
       form.AddField("answer_3",answer_3);
       form.AddField("answer_4",answer_4);
       form.AddField("correct_answer",correct_answer);
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       form.AddField("assignment_id",assignment_id);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/insert_assignment_question.php",form)) // sending inputs to be queried, will be done by php
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
  
 
}


[Serializable]
public class questionData
{
    public string question_description;
    public string answer_1;
    public string answer_2;
    public string answer_3;
    public string answer_4;
    public string correct_answer;
	public string topic;
	public string difficulty;
	public string assignment_id;
}

[Serializable]
public class questionData_list {
    public questionData[] question_data;
}


[Serializable]
public class leaderboardData
{
    public string username;
    public string score;
	public string topic;
	public string difficulty;
}

[Serializable]
public class leaderboard_list {
    public leaderboardData[] leaderboard_data;
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
