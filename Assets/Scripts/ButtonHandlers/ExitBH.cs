using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitBH : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        exitButton.onClick.AddListener(exitGame);
    }
   
    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }
}
