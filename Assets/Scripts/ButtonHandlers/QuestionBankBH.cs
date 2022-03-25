using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionBankBH : MonoBehaviour
{

    public Button addQuestionButton, editQuestionButton, exitButton, goBackButton;
    // Start is called before the first frame update
    void Start()
    {
        addQuestionButton.onClick.AddListener(addQuestion);
        editQuestionButton.onClick.AddListener(editQuestion);
        exitButton.onClick.AddListener(exitGame);
        goBackButton.onClick.AddListener(goBackMainMenu);
        

    }

    public void addQuestion(){
        SceneManager.LoadScene("Question - Add Question (Teacher)");
    }

    
    public void editQuestion(){
        SceneManager.LoadScene("Question - View Question (Teacher)");
    }

    public void goBackMainMenu(){
        SceneManager.LoadScene("Main Menu (Teacher)");
    }

     void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
