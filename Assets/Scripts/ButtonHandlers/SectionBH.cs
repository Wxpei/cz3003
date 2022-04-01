using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class SectionBH : MonoBehaviour
{
    public Button exitButton, goBackButton;

    [SerializeField]
    private GameObject topicButtonTemplate;

    public Text subject;

    public List<string> Topics;

    private List<GameObject> topicButtons = new List<GameObject>();

    public IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackWorldSelection);
        exitButton.onClick.AddListener(exitGame);

        subject.text = SceneTransfer.subject;

        LoadDefaultTopics();
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

    void goDifficultySelection()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void LoadTopicsFromDatabase(string subject)
    {
        // Add code to load from database
        // populate questionDatabase
    }

    public void LoadDefaultTopics()
    {
        // Default Topics
        if (SceneTransfer.subject == "math")
        {
            Topics.Add("Topic 1: Numbers");
            Topics.Add("Topic 2: Algebra");
            Topics.Add("topic3");
            Topics.Add("topic4");
            Topics.Add("topic5");
        }
        else if (SceneTransfer.subject == "science")
        {
            Topics.Add("Topic 1: Atom");
            Topics.Add("Topic 2: Algebra");
            Topics.Add("topic3");
            Topics.Add("topic4");
            Topics.Add("topic5");
        }
        else if (SceneTransfer.subject == "history")
        {
            Topics.Add("Topic 1: Cold War");
            Topics.Add("Topic 2: World War I");
            Topics.Add("Topic 3: World War II");
            Topics.Add("topic4");
            Topics.Add("topic5");
        }

        var position = topicButtonTemplate.transform.position;
        var y = position.y;
        foreach (var topic in Topics)
        {
            Debug.Log(topic);
            GameObject topicButton = Instantiate(topicButtonTemplate) as GameObject;
            topicButton.SetActive(true);

            topicButton.GetComponent<Button>().onClick.AddListener(goDifficultySelection);

            Text indexText = topicButton.transform.GetChild(0).GetComponent<Text>();
            indexText.text = topic;
            topicButton.transform.SetParent(topicButtonTemplate.transform.parent, false);

            topicButton.transform.position = new Vector3(position.x, y, position.z);
            topicButtons.Add(topicButton.gameObject);
            y = y - 225;
            
        }
    }
}
