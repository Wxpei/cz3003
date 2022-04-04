using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ProfilePwdBH : MonoBehaviour
{
    public Button exitButton, goBackButton, changePasswordButton;

    public Text messageText;

    public InputField pwd1, pwd2;

    public IEnumerator coroutine;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        // Profile Page Canvas
        changePasswordButton.onClick.AddListener(updatePwd);

        goBackButton.onClick.AddListener(goBackProfile);
        exitButton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackProfile()
    {
            Debug.Log("Back selected. Load Main Menu (Student).");
            SceneManager.LoadScene("Profile");
    }

    void updatePwd()
    {
        Debug.Log("Password Updated. Load Profile Canvas.");
        string pwd = null;
        if (pwd1.text != pwd2.text || pwd == null)
        {
            messageText.text = "Password does not match!";
        }
        else
        {
            pwd = pwd1.text;
        }
        //Add update pwd to database
        //coroutine = update_userDetails(SceneTransfer.username, pwd);
        //Debug.Log(SceneTransfer.username);
        //StartCoroutine(coroutine);
    }

    public IEnumerator update_userDetails(string username, string password) // verify login, password is hashed aka send date to database
    {
        WWWForm form = new WWWForm();
        form.AddField("loginuser", username);
        form.AddField("loginpass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/update_user_details.php", form))
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
                messageText.text = "Password Updated";
            }
        }
    }
}

