using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class StudentStatisticsBH : MonoBehaviour
{
    // Start is called before the first frame update
    public Button goBackButton, exitButton, searchButton;

    public InputField studentName;

    [SerializeField]
    private GameObject statisticsTemplate;

    [SerializeField]
    private Transform statisticsContent;

    public List<GameObject> statistics = new List<GameObject>();

    public IEnumerator coroutine;

    void Start()
    {
        goBackButton.onClick.AddListener(goBackMainMenu);
        exitButton.onClick.AddListener(exitGame);
        searchButton.onClick.AddListener(searchStudent);

        // Set the assignment_id for the GameManager to retreive questions | Default is 0
    }
    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenu()
    {
        SceneManager.LoadScene("Main Menu (Teacher)");
    }

    void searchStudent()
    {
        LoadLeaderboardFromDatabase(studentName.text);
    }

    void LoadLeaderboardFromDatabase(string username)
    {
        coroutine = get_leaderboard(username);
        StartCoroutine(coroutine);
    }

    public IEnumerator get_leaderboard(string username1)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username1);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/fetch_statistics.php", form)) // sending inputs to be queried, will be done by php
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                foreach(GameObject go in statistics) 
                { 
                    Destroy(go);
                }

                statistics.Clear();

                //Debug.Log(www.downloadHandler.text); // The json string returned by the php file
                string jsonArray = www.downloadHandler.text;
                //Debug.Log(jsonArray);

                leaderboard_list leaderboardList = JsonUtility.FromJson<leaderboard_list>("{\"leaderboard_data\": " + jsonArray + "}");

                var position = statisticsTemplate.transform.position;
                var y = position.y;
                for (int i = 0; i < leaderboardList.leaderboard_data.Length; i++)
                {
                    GameObject rank = Instantiate(statisticsTemplate, statisticsContent);

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

                    statistics.Add(rank.gameObject);
                }
            }
        }
    }
}
