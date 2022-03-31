using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class TopicBH : MonoBehaviour
{
    public Button exitButton, goBackButton;

    [SerializeField]
    private GameObject topicTemplate;

    public Text subject;

    public List<string> Topics;

    private List<GameObject> ranks = new List<GameObject>();

    public IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackWorldSelection);
        exitButton.onClick.AddListener(exitGame);

        subject.text = SceneTransfer.subject;


        // Default Topics
        Topics.Add("topic1");
        Topics.Add("topic2");
        Topics.Add("topic3");
        Topics.Add("topic4");
        Topics.Add("topic5");

        var position = topicTemplate.transform.position;
        var y = position.y;
        foreach (var topic in Topics)
        {
            Debug.Log(topic);
            GameObject rank = Instantiate(topicTemplate) as GameObject;
            rank.SetActive(true);

            Text indexText = rank.transform.GetChild(0).GetComponent<Text>();
            indexText.text = topic;
            rank.transform.SetParent(topicTemplate.transform.parent, false);
           
            rank.transform.position = new Vector3(position.x, y, position.z);
            ranks.Add(rank.gameObject);
            y = y - 250;
        }

        
    }

    // Update is called once per frame
    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackWorldSelection()
    {
        SceneManager.LoadScene("World Selection");
    }
    public void LoadTopicsFromDatabase(string subject)
    {
        // Add code to load from database
        coroutine = get_topics(subject);
        StartCoroutine(coroutine);
        // populate questionDatabase
    }

    public IEnumerator get_topics(string subject)
    {
        WWWForm form = new WWWForm();
        form.AddField("topic", subject);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/fetch_topics.php", form)) // sending inputs to be queried, will be done by php
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                
            }
        }
    }
}
