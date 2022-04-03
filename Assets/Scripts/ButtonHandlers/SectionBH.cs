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

        subject.text = SceneTransfer.subject.ToUpper() + " Topic Selection";

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
            Topics.Add("Topic 3: Geometry and Measurements");
            Topics.Add("Topic 4: Statistics");
            Topics.Add("Topic 5: Probability");
        }
        else if (SceneTransfer.subject == "science")
        {
            Topics.Add("Topic 1: Atoms and Molecules");
            Topics.Add("Topic 2: Chemical Composition");
            Topics.Add("Topic 3: Cells");
            Topics.Add("Topic 4: Human Digestive System");
            Topics.Add("Topic 5: Human Reproductive System");
        }
        else if (SceneTransfer.subject == "history")
        {
            Topics.Add("Topic 1: The World in Crisis");
            Topics.Add("Topic 2: Bi-Polarity and the Cold War");
            Topics.Add("Topic 3: World War I");
            Topics.Add("Topic 4: World War II");
        }
        else if (SceneTransfer.subject == "geography")
        {
            Topics.Add("Topic 1: Map Work");
            Topics.Add("Topic 2: Rocks");
            Topics.Add("Topic 3: Land Forms");
            Topics.Add("Topic 4: Climate");
            Topics.Add("Topic 5: The Environment");
        }
        else if (SceneTransfer.subject == "social studies")
        {
            Topics.Add("Topic 1: Citizenship and Governance");
            Topics.Add("Topic 2: Living in a Diverse Society");
            Topics.Add("Topic 3: Being Part of a Globalised World");
        }

        var position = topicButtonTemplate.transform.position;
        var y = position.y;
        foreach (var topic in Topics)
        {
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
