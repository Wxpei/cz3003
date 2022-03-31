using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLife = 3;
    public int numberOfChest = 5;
    public float questionTimer = 20.0f;
    public List<Question> questionDatabase;
    public QuestionPanel questionPanel;
    public HeartManager heartManager;

    public Text scoreText;

    [Header("Private Fields")]
    [SerializeField]
    private List<Question> currentQuestion;
    private int chestOpened = 0;

    [SerializeField]
    private int playerScore = 0;
    private int questionScore = 1;
    private int playerLifeCounter = 0;

    [SerializeField]
    private float gameTimer = 0;

    private bool gameEnd = false;

    public IEnumerator coroutine;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load Data from previous scene here
        string difficulty = SceneTransfer.difficulty;
        string subject = SceneTransfer.subject;

        playerLife = 3;


        switch (difficulty)
        {
            case "easy":
                questionScore = 1; // score for correct question for easy mode
                questionTimer = 10.0f;
                break;
            case "normal":
                questionScore = 2; // score for correct question for medium mode
                questionTimer = 15.0f;
                break;
            case "hard":
                questionScore = 3; // score for correct question for hard mode
                questionTimer = 20.0f;
                break;
        }

        if (SceneTransfer.avatarTime)
        {
            questionTimer += 5.0f;
        } 
        else if (SceneTransfer.avatarLife)
        {
            playerLife++;
        }

        scoreText.text = "0"; // Initialise score to 0

        InitialisePlayerHealth(); // setup player health system
        LoadQuestionsFromDatabase(difficulty, subject); // load all questions from database
        GetPoolOfQuestions(); // will randomly select 5 qn from all questions
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd && (chestOpened == numberOfChest || playerLifeCounter == 0))
        {
            gameEnd = true;
            GameEnd();

        } else if (!gameEnd)
        {
            gameTimer += Time.deltaTime;
        }
    }

    public void TriggerQuestion(ChestCollectable chest)
    {
        questionPanel.LoadQuestion(currentQuestion[chestOpened], questionTimer, chestOpened + 1);
    }

    public void LoadQuestionsFromDatabase(string difficulty, string subject)
    {
        // Add code to load from database
        coroutine = get_questions(subject, difficulty);
        StartCoroutine(coroutine);
        // populate questionDatabase
    }

    public IEnumerator get_questions(string topic, string difficulty)
    {
        WWWForm form = new WWWForm();
        form.AddField("topic", topic);
        form.AddField("difficulty", difficulty);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/fetch_questions_2.php", form)) // sending inputs to be queried, will be done by php
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                questionDatabase.Clear();
                Debug.Log(www.downloadHandler.text); // The json string returned by the php file
                string jsonArray = www.downloadHandler.text;
                questionData_list questionlist = JsonUtility.FromJson<questionData_list>("{\"question_data\": " + jsonArray + "}");
                //As there maybe multiple outputs, we have to store the results as a list
                // Select the first line from the collection, and print its dialogue:

               
                for (int i = 0; i < questionlist.question_data.Length; i++)
                {
                    string questionText = questionlist.question_data[i].question_description;
                    string[] answerText = new string[4];
                    answerText[0] = questionlist.question_data[i].answer_1;
                    answerText[1] = questionlist.question_data[i].answer_2;
                    answerText[2] = questionlist.question_data[i].answer_3;
                    answerText[3] = questionlist.question_data[i].answer_4;
                    int answerOption = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        if (answerText[j] == questionlist.question_data[i].correct_answer)
                        {
                            Debug.Log(questionlist.question_data[i].correct_answer);
                            Debug.Log(questionlist.question_data[i].correct_answer);
                            answerOption = j + 1;
                            break;
                        }
                    }
                    Question qn = new Question(questionText, answerText, answerOption);
                    questionDatabase.Add(qn);
                }


            }
        }

        GetPoolOfQuestions(); // will randomly select 5 qn from all questions
    }

    private void GameEnd()
    {
        // Upload playerScore, gameTimer, username (SceneTransfer.username) to database

        SceneManager.LoadScene("Leaderboard");
    }

    public void FinishQuestion(bool success)
    {
        chestOpened++;

        if (!success)
        {
            // Lose life
            heartManager.DeductLife();
            playerLifeCounter--;

        } else
        {
            playerScore += questionScore;
            scoreText.text = playerScore.ToString();
        }
    }

    private void InitialisePlayerHealth()
    {
        playerLifeCounter = playerLife;
        heartManager.SetupHeartManager(playerLife);
    }

    private void GetPoolOfQuestions()
    {
        List<Question> copy = new List<Question>(questionDatabase);
        currentQuestion = new List<Question>();

        for (int i = 0; i < 5; i++)
        {
            int qnSelected = Random.Range(0, copy.Count);

            currentQuestion.Add(copy[qnSelected]);
            copy.RemoveAt(qnSelected);
        }
    }
}

