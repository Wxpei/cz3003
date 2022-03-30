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



    public Button goBackButton, exitButton, loadButton;
    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackQuestionBank);
        exitButton.onClick.AddListener(exitGame);
        //loadButton.onClick.AddListener(loadQuestions);
    }

    public void goBackQuestionBank(){
        SceneManager.LoadScene("Question - Question Bank (Teacher)");
    }

    public void exitGame(){
        Application.Quit();
    }

    // public void loadQuestions(){
        
    // }




    // Update is called once per frame
    void Update()
    {

    }
}
