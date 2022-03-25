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
    





    // Start is called before the first frame update
    void Start()
    {
        
          getQuestion(getTopic(), getDiff());
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

      void ButtonClicked(int buttonNo)
    {
        Debug.Log ("Button clicked = " + buttonNo);
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
        coroutine = get_questions(topic,diff);
        StartCoroutine(coroutine);

        Debug.Log("get question end");
    }

      public IEnumerator get_questions(string topic, string difficulty)
   {
       WWWForm form = new WWWForm();
       form.AddField("topic",topic); 
       form.AddField("difficulty",difficulty);
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/cz3003/fetch_questions.php",form)) // sending inputs to be queried, will be done by php
       {
           yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
           else
           {
               Debug.Log(www.downloadHandler.text); // The json string returned by the php file
               string jsonArray = www.downloadHandler.text;
               Debug.Log(jsonArray);
               questionData_list questionlist = JsonUtility.FromJson<questionData_list>("{\"question_data\": " + jsonArray + "}");
			   //As there maybe multiple outputs, we have to store the results as a list
               // Select the first line from the collection, and print its dialogue:
               List<string> tempList = new List<string>();

               for(int i =0; i<2;i++)
               {
               Debug.Log("User 1  = " + questionlist.question_data[i].question_description);
               tempList.Add(questionlist.question_data[i].question_description);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_1);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_2);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_3);
               Debug.Log("User 1  = " + questionlist.question_data[i].answer_4);
               Debug.Log("User 1  = " + questionlist.question_data[i].correct_answer);
			   Debug.Log("User 1  = " + questionlist.question_data[i].topic);
			   Debug.Log("User 1  = " + questionlist.question_data[i].difficulty);
			   Debug.Log("User 1  = " + questionlist.question_data[i].assignment_id);
                }

                 for(int i = 0; i < tempList.Count; i++)
        {
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;
            tempButton.GetComponentInChildren<Text>().text = tempList[i];

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }

            
            
           }
       }
   }

    void Update()
    {
        getQuestion(getTopic(),getDiff());
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
}

}



