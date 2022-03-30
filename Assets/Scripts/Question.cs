using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;
    public int answerOption;
    public string[] answerText = new string[4];

    public Question(string questionText, string[] answerText, int answerOption)
    {
        this.questionText = questionText;
        this.answerOption = answerOption;
        this.answerText = answerText;
    }
}