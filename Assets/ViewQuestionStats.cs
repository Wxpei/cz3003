using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class ViewQuestionStats : MonoBehaviour
{

    public Button editButton, exitButton, goBackButton;
    public IEnumerator coroutine;
    public Text question, topic, difficulty, option1, option2,
                option3, option4, correct_answer, correct_attempts,
                total_attempts, percentage;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(QuestionList.question_description);
        question.text += QuestionList.question_description;
        topic.text += QuestionList.topic;
        difficulty.text += QuestionList.difficulty;
        option1.text += QuestionList.answer_1;
        option2.text += QuestionList.answer_2;
        option3.text += QuestionList.answer_3;
        option4.text += QuestionList.answer_4;
        correct_answer.text += QuestionList.correct_answer;
        correct_attempts.text += QuestionList.correct_attempts;
        total_attempts.text += QuestionList.total_attempts;
        if (QuestionList.percentage != 0){
            percentage.text += QuestionList.percentage + "%";
        } else{
            percentage.text += "-";
        }

        goBackButton.onClick.AddListener(goBackQuestionBank);
        exitButton.onClick.AddListener(exitGame);
        editButton.onClick.AddListener(editQuestion);
    }

    public void editQuestion(){
        SceneManager.LoadScene("Question - Edit Question (Teacher)");
    }

    public void goBackQuestionBank(){
        SceneManager.LoadScene("Question - View Question (Teacher)");
    }

    public void exitGame(){
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
