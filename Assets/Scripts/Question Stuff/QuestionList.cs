using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;



 public class CoroutineWithData {
     public Coroutine coroutine { get; private set; }
     public object result;
     private IEnumerator target;
     public CoroutineWithData(MonoBehaviour owner, IEnumerator target) {
         this.target = target;
         this.coroutine = owner.StartCoroutine(Run());
     }
 
     private IEnumerator Run() {
         while(target.MoveNext()) {
             result = target.Current;
             yield return result;
         }
     }
 }

public class QuestionList : MonoBehaviour
{
        public IEnumerator coroutine; 
        public Transform topicList, diffList;
        public GameObject prefabButton;
        public RectTransform ParentPanel;
        public Button loadButton;

        public questionData_list questionlist; // list of questions
        public static questionData selectedQuestion; // selected question data
        public static int question_id;
        public static string question_description;
        public static string answer_1;
        public static string answer_2;
        public static string answer_3;
        public static string answer_4;
        public static string correct_answer;
        public static string correct_option;
        public static string topic;
        public static string difficulty;
        public static int correct_attempts;
        public static int total_attempts;
        public static double percentage = 0;
        

    // Start is called before the first frame update
    void Start()
    {
        loadButton.onClick.AddListener(loadQuestions);
        //   getQuestion(getTopic(), getDiff());
        // getQuestionButton.onClick.AddListener(getQuestion);

   
        //  for(int i = 0; i < 5; i++)
        // {
        //     GameObject goButton = (GameObject)Instantiate(prefabButton);
        //     goButton.transform.SetParent(ParentPanel, false);
        //     goButton.transform.localScale = new Vector3(1, 1, 1);

        //     Button tempButton = goButton.GetComponent<Button>();
        //     int tempInt = i;
        //     tempButton.GetComponentInChildren<Text>().text = "my button text";

        //     tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        // }
    }

    public void loadQuestions(){
        getQuestion(getTopic(), getDiff());
    }

      void ButtonClicked(int buttonNo)
    {
        Debug.Log ("Button clicked = " + buttonNo);
        selectQuestion(buttonNo);
        // SceneManager.LoadScene("Question - Edit Question (Teacher)");
        SceneManager.LoadScene("Question - Question Statistics (Teacher)");
    }

    public void selectQuestion(int i){
        question_id = questionlist.question_data[i].question_id;
        question_description = questionlist.question_data[i].question_description;
        answer_1 = questionlist.question_data[i].answer_1;
        answer_2 = questionlist.question_data[i].answer_2;
        answer_3 = questionlist.question_data[i].answer_3;
        answer_4 = questionlist.question_data[i].answer_4;
        correct_answer = questionlist.question_data[i].correct_answer;
        correct_attempts = questionlist.question_data[i].correct_attempts;
        total_attempts = questionlist.question_data[i].total_attempts;
        if (total_attempts != 0) {
            percentage = (Math.Round((double)correct_attempts/total_attempts, 2)) * 100;
        }
        Debug.Log("Percentage: " + percentage);
        string[] answers = {answer_1, answer_2, answer_3, answer_4};
        List<string> answerList = new List<string>(answers);
        for (int j = 0; j < answerList.Count; j++){
            if (answerList[j] == correct_answer) {
                correct_option = j.ToString();
            }
        }
        
        topic = questionlist.question_data[i].topic;
        difficulty = questionlist.question_data[i].difficulty;
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

    void getQuestion(string topic, string diff){
        clearQuestions();
        coroutine = get_questions(topic,diff);
        StartCoroutine(coroutine);

        Debug.Log("get question end");
    }


    void clearQuestions(){
                int temp = 0;
               foreach (RectTransform child in ParentPanel)
                { 
                    if(temp !=0){
                        Destroy(child.gameObject);
                    }
                    temp+=1;
                     
                }
    }
      public IEnumerator get_questions(string topic, string difficulty)
   {
       WWWForm form = new WWWForm();
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/fetch_questions.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               //Debug.Log(www.downloadHandler.text); // The json string returned by the php file
               string jsonArray = www.downloadHandler.text;
               //Debug.Log(jsonArray);
               //questionData_list questionlist = JsonUtility.FromJson<questionData_list>("{\"question_data\": " + jsonArray + "}");
               questionlist = JsonUtility.FromJson<questionData_list>("{\"question_data\": " + jsonArray + "}");
               
			   //As there maybe multiple outputs, we have to store the results as a list
               // Select the first line from the collection, and print its dialogue:
               List<string> tempList = new List<string>();
               foreach(questionData qd in questionlist.question_data){
                   if (qd != null){
                    tempList.Add(qd.question_description);
                   }
                } 

            //    for(int i =0; i<2;i++)
            //    {
            //    Debug.Log("User 1  = " + questionlist.question_data[i].question_description);
            //   tempList.Add(questionlist.question_data[i].question_description);
            //    Debug.Log("User 1  = " + questionlist.question_data[i].answer_1);
            //    Debug.Log("User 1  = " + questionlist.question_data[i].answer_2);
            //    Debug.Log("User 1  = " + questionlist.question_data[i].answer_3);
            //    Debug.Log("User 1  = " + questionlist.question_data[i].answer_4);
            //    Debug.Log("User 1  = " + questionlist.question_data[i].correct_answer);
			//    Debug.Log("User 1  = " + questionlist.question_data[i].topic);
			//    Debug.Log("User 1  = " + questionlist.question_data[i].difficulty);
			//    Debug.Log("User 1  = " + questionlist.question_data[i].assignment_id);
            //     }

            
                 for(int i = 0; i < tempList.Count; i++)
            {
                GameObject goButton = (GameObject)Instantiate(prefabButton);
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);

                Button tempButton = goButton.GetComponent<Button>();
                int tempInt = i;
                tempButton.GetComponentInChildren<Text>().text = tempList[i];

                tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
                // Destroy(tempButton.GetComponent<Button>());
            

            }
           
        
            
           }
       }
   }


    void Update()
    {
        topicList.GetComponent<Dropdown>().RefreshShownValue();
        diffList.GetComponent<Dropdown>().RefreshShownValue();
    }

    // Please copy the functions below to everyfile scriptfile
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

    [Serializable]
    public class questionData
    {
        public int question_id;
        public string question_description;
        public string answer_1;
        public string answer_2;
        public string answer_3;
        public string answer_4;
        public string correct_answer;
        public string topic;
        public string difficulty;
        public string assignment_id;
        public int correct_attempts;
        public int total_attempts;
        public double percentage;
    }

    [Serializable]
    public class questionData_list {
        public questionData[] question_data;
    }
}

}




