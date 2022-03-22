using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        backButton.onClick.AddListener(Back);
    }
    public void Back()
    {
        SceneManager.LoadScene("Login");
        Debug.Log("Back selected. Load Login Scene.");
    }

}
