using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ProfileBH : MonoBehaviour
{
    public Button exitButton, goBackButton, changePasswordButton;

    public Text username, uname, email;

    public IEnumerator coroutine;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        changePasswordButton.onClick.AddListener(changePassword);

        goBackButton.onClick.AddListener(goBackMainMenuStudent);
        exitButton.onClick.AddListener(exitGame);


        SceneTransfer.username = "test1";

        username.text = "Username: " + SceneTransfer.username;

        // Get email and naem from database
        coroutine = get_userDetails(SceneTransfer.username);
        Debug.Log(SceneTransfer.username);
        StartCoroutine(coroutine);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenuStudent()
    {
        Debug.Log("Back selected. Load Main Menu (Student).");
        SceneManager.LoadScene("Main Menu (Student)");
    }
    void changePassword()
    {
        Debug.Log("Change Password selected. Load Password Canvas.");
        SceneManager.LoadScene("Profile (Pwd)");
    }

    public IEnumerator get_userDetails(string username) // verify login, password is hashed aka send date to database
    {
        WWWForm form = new WWWForm();
        form.AddField("loginuser", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/fetch_user_details.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                
                Debug.Log("data from SQL: " + jsonArray);

                var userdetails = JsonUtility.FromJson<userData>(jsonArray);

                uname.text = "Name: " + userdetails.Name;
                email.text = "Email: " + userdetails.Email;

            }
        }
    }
}

