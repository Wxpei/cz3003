using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class ViewQuestionBH : MonoBehaviour
{



    public Button goBackButton, exitButton, questionButton;
    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackQuestionBank);
        exitButton.onClick.AddListener(exitGame);
    }

    public void goBackQuestionBank(){
        SceneManager.LoadScene("Question - Question Bank (Teacher)");
    }

    public void exitGame(){
        Application.Quit();
    }






    // Update is called once per frame
    void Update()
    {

    }
}
