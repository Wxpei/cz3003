using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LeaderboardBH : MonoBehaviour
{
    public Button exitButton, goBackButton;

    public Text leaderboardtitle;

    public Canvas normalLeaderboard;
    public Canvas customLeaderboard;

    [SerializeField]
    private GameObject rankTemplate;

    [SerializeField]
    private GameObject rankCustomTemplate;

    public List<Leaderboard> leaderboard;
    public List<GameObject> ranks = new List<GameObject>();

    public IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackMainMenu);
        exitButton.onClick.AddListener(exitGame);

        if (SceneTransfer.assignment_id == 0)
        {
            normalLeaderboard.enabled = true;
            customLeaderboard.enabled = false;
            LoadLeaderboardFromDatabase(SceneTransfer.subject, SceneTransfer.difficulty);
        }
        else
        {
            normalLeaderboard.enabled = false;
            customLeaderboard.enabled = true;
            LoadCustomLeaderboardFromDatabase(SceneTransfer.assignment_id);
        }
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenu()
    {
        SceneManager.LoadScene("Main Menu (" + SceneTransfer.accountType + ")");
    }

    void LoadLeaderboardFromDatabase(string topic, string difficulty)
    {
        coroutine = get_leaderboard(topic, difficulty);
        StartCoroutine(coroutine);
    }
    
    void LoadCustomLeaderboardFromDatabase(int assignment_id)
    {
        coroutine = get_Custom_leaderboard(assignment_id);
        StartCoroutine(coroutine);
    }

    public IEnumerator get_leaderboard(string topic, string difficulty)
    {
        WWWForm form = new WWWForm();
        form.AddField("topic", topic);
        form.AddField("difficulty", difficulty);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/fetch_leaderboard.php", form)) // sending inputs to be queried, will be done by php
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

                leaderboard_list leaderboardList = JsonUtility.FromJson<leaderboard_list>("{\"leaderboard_data\": " + jsonArray + "}");

                var position = rankTemplate.transform.position;
                var y = position.y;
                for (int i = 0; i < leaderboardList.leaderboard_data.Length; i++)
                {
                    GameObject rank = Instantiate(rankTemplate) as GameObject;
                    rank.SetActive(true);

                    string username = leaderboardList.leaderboard_data[i].username;
                    string score = leaderboardList.leaderboard_data[i].score;
                    string subject = leaderboardList.leaderboard_data[i].topic;
                    string level = leaderboardList.leaderboard_data[i].difficulty;

                    Text userText = rank.transform.GetChild(0).GetComponent<Text>();
                    userText.text = username;
                    Text scoreText = rank.transform.GetChild(1).GetComponent<Text>();
                    scoreText.text = score;
                    Text subjectText = rank.transform.GetChild(2).GetComponent<Text>();
                    subjectText.text = subject;
                    Text levelText = rank.transform.GetChild(3).GetComponent<Text>();
                    levelText.text = level;

                    rank.transform.SetParent(rankTemplate.transform.parent, false);
                    rank.transform.position = new Vector3(position.x, y, position.z);
                    ranks.Add(rank.gameObject);
                    y = y - 250;
                }
            }
        }
    }

    public IEnumerator get_Custom_leaderboard(int assignment_id)
    {
        leaderboardtitle.text = "Leaderboard (Room " + assignment_id + ")";

        WWWForm form = new WWWForm();
        form.AddField("assignment_id", assignment_id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/cz3003/fetch_custom_leaderboard.php", form)) // sending inputs to be queried, will be done by php
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
                
                leaderboard_list leaderboardList = JsonUtility.FromJson<leaderboard_list>("{\"leaderboard_data\": " + jsonArray + "}");

                var position = rankCustomTemplate.transform.position;
                var y = position.y;

                for (int i = 0; i < leaderboardList.leaderboard_data.Length; i++)
                {
                    GameObject rank = Instantiate(rankCustomTemplate) as GameObject;
                    rank.SetActive(true);

                    string username = leaderboardList.leaderboard_data[i].username;
                    string score = leaderboardList.leaderboard_data[i].score;
                    string time = leaderboardList.leaderboard_data[i].time;

                    Text userText = rank.transform.GetChild(0).GetComponent<Text>();
                    userText.text = username;
                    Text scoreText = rank.transform.GetChild(1).GetComponent<Text>();
                    scoreText.text = score;
                    Text timeText = rank.transform.GetChild(2).GetComponent<Text>();
                    timeText.text = time;

                    rank.transform.SetParent(rankCustomTemplate.transform.parent, false);
                    rank.transform.position = new Vector3(position.x, y, position.z);
                    ranks.Add(rank.gameObject);
                    y = y - 250;
                }

            }
        }
    }
}
