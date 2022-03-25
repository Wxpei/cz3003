using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditQuestionBH1 : MonoBehaviour
{

    public Button saveButton, exitButton, goBackButton;

    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackQuestionBank);
        exitButton.onClick.AddListener(exitGame);
        saveButton.onClick.AddListener(saveQuestion);
    }

     public void saveQuestion(){
        Debug.Log("Save question button pressed");
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
