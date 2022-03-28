using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using System.Linq;






public class AddQuestionBH : MonoBehaviour
{
    public Button saveButton, exitButton, goBackButton;
    public Transform topicList, diffList; 
    public InputField desc, option1, option2, option3, option4;  
    public IEnumerator coroutine;
    public ToggleGroup toggleGroup;


    // Start is called before the first frame update
    void Start()
    {
        // toggleGroup = GetComponent<ToggleGroup>();
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
        Debug.Log("current selection: " + correct_selection);
        string question_description = desc.text;
        string answer_1 = option1.text;
        string answer_2 = option2.text;
        string answer_3 = option3.text;
        string answer_4 = option4.text;
        string correct_answer; 
        switch (correct_selection){
            case "Option1Answer":
                correct_answer = option1.text;
                break;
            case "Option2Answer": 
                correct_answer = option2.text;
                break;
            case "Option3Answer":
                correct_answer = option3.text;
                break;
            case "Option4Answer":
                correct_answer = option4.text;
                break;
            default:
                correct_answer = option1.text;
                break;
        }
 
        string topic = getTopic(); 
        string difficulty = getDiff();
        Debug.Log(topic);
        addQuestion(question_description, answer_1, answer_2, answer_3, answer_4, correct_answer, topic, difficulty);
    }

    public void goBackQuestionBank(){
        SceneManager.LoadScene("Question - Question Bank (Teacher)");
    }

    public void exitGame(){
        Application.Quit();
    }

    void addQuestion(string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty){
   
     
        coroutine = insert_question(question_description, answer_1, answer_2, answer_3, answer_4, correct_answer, topic, difficulty);
        StartCoroutine(coroutine);
        Debug.Log("finish coroutine");
    }


      public IEnumerator insert_question(string question_description, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer, string topic, string difficulty)
    {
       WWWForm form = new WWWForm();
       form.AddField("question_description",question_description);
       form.AddField("answer_1",answer_1);
       form.AddField("answer_2",answer_2);
       form.AddField("answer_3",answer_3);
       form.AddField("answer_4",answer_4);
       form.AddField("correct_answer",correct_answer);
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       Debug.Log("here");
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/cz3003/insert_question.php",form)) // sending inputs to be queried, will be done by php
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

    // Update is called once per frame
    void Update()
    {
        
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
