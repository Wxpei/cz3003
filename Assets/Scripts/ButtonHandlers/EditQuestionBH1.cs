using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.Linq;

public class EditQuestionBH1 : MonoBehaviour
{

    public Button saveButton, exitButton, goBackButton;
    public Transform topicList, diffList; 
    public InputField desc, option1, option2, option3, option4;  
    public IEnumerator coroutine;
    public ToggleGroup toggleGroup;
    public static int question_id;

    // Start is called before the first frame update
    void Start()
    {
    
        Debug.Log("correct option/togglename: "+ QuestionList.correct_option);
        question_id = QuestionList.question_id;
        desc.text = QuestionList.question_description;
        option1.text = QuestionList.answer_1;
        option2.text = QuestionList.answer_2;
        option3.text = QuestionList.answer_3;
        option4.text = QuestionList.answer_4;

        topicList.GetComponent<Dropdown>().value = topicList.GetComponent<Dropdown>().options.FindIndex(option => option.text == QuestionList.topic);
        int topicindex = topicList.GetComponent<Dropdown>().value;
        //topicList.GetComponent<Dropdown>().captionText.text = topicList.GetComponent<Dropdown>().options[topicindex].text;

        Debug.Log("Difficulty: " + QuestionList.difficulty);
        GameObject.Find("Dropdown - Difficulty List").GetComponent<Dropdown>().value = 1;
        // diffList.GetComponent<Dropdown>().value = diffList.GetComponent<Dropdown>().options.FindIndex(option => option.text == QuestionList.difficulty);
        // int diffindex = diffList.GetComponent<Dropdown>().value;
        // diffList.GetComponent<Dropdown>().captionText.text = diffList.GetComponent<Dropdown>().options[diffindex].text;
        
        //toggleGroup.SetAllTogglesOff();
        //GameObject.Find(QuestionList.correct_option).GetComponent<Toggle>().isOn = true;

        goBackButton.onClick.AddListener(goBackQuestionBank);
        exitButton.onClick.AddListener(exitGame);
        saveButton.onClick.AddListener(saveQuestion);
        
    }

    public Toggle currentSelection{
        get { return toggleGroup.ActiveToggles().FirstOrDefault();}
    }

    string getTopic(){
        int topicIndex = topicList.GetComponent<Dropdown> ().value;

        List<Dropdown.OptionData> topicOptions = topicList.GetComponent<Dropdown>().options;

        string topic = topicOptions [topicIndex].text;

        return topic;
    }
    //Access lists text 

    string getDiff(){
        int diffIndex = diffList.GetComponent<Dropdown> ().value;

        List<Dropdown.OptionData> diffOptions = diffList.GetComponent<Dropdown>().options;

        string diff = diffOptions [diffIndex].text;

        return diff;
    }


    public void saveQuestion(){
        Debug.Log(desc.text);
        Debug.Log("Save question button pressed");
        // Debug.Log("selected " + currentSelection.name);
        string correct_selection = currentSelection.name;
        int x;
        int.TryParse(correct_selection, out x);
        Debug.Log("x: " + x);
        Debug.Log("current selection: " + correct_selection);
        string question_description = desc.text;
        string answer_1 = option1.text;
        string answer_2 = option2.text;
        string answer_3 = option3.text;
        string answer_4 = option4.text;
        string correct_answer;
        switch (x){
            case 0:
                correct_answer = answer_1;
                break;
            case 1: 
                correct_answer = answer_2;
                break;
            case 2:
                correct_answer = answer_3;
                break;
            case 3:
                correct_answer = answer_4;
                break;
            default:
                correct_answer = answer_4;
                break;
        }
        
        Debug.Log("correct_answer: " + correct_answer);
        string topic = getTopic(); 
        string difficulty = getDiff();
        Debug.Log("Topic: " + topic);
        Debug.Log("Diff: " + difficulty);
        updateQuestion(question_id, question_description, answer_1, answer_2, answer_3, answer_4, correct_answer, topic, difficulty);
    }

    void updateQuestion(int question_id, string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty){
   
        coroutine = update_question(question_id, question_description, answer_1, answer_2, answer_3, answer_4, correct_answer, topic, difficulty);
        StartCoroutine(coroutine);
        Debug.Log("finish coroutine");
    }

    public IEnumerator update_question(int question_id, string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty)
    {
       WWWForm form = new WWWForm();
       form.AddField("question_id",question_id);
       form.AddField("question_description",question_description);
       form.AddField("answer_1",answer_1);
       form.AddField("answer_2",answer_2);
       form.AddField("answer_3",answer_3);
       form.AddField("answer_4",answer_4);
       form.AddField("correct_answer",correct_answer);
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/update_question.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text); // The json string returned by the php file
           }
       }
    }

    public void goBackQuestionBank(){
        SceneManager.LoadScene("Question - Question Statistics (Teacher)");
    }

    public void exitGame(){
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        topicList.GetComponent<Dropdown>().RefreshShownValue();
        diffList.GetComponent<Dropdown>().RefreshShownValue();
    }
     public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
}
