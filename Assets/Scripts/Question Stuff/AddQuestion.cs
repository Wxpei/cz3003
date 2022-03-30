using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class AddQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
       using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/insert_question.php",form)) // sending inputs to be queried, will be done by php
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
