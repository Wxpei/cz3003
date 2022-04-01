using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    public Text questionNumberText;
    public Text questionText;
    public List<Text> answerText;
    public int questionID;

    public Text timerText;

    public Animator bombAnimator;
    public Animator playerAnimator;

    private CanvasGroup canvasGroup;

    private float timerCounter;

    private Question currentQuestion;

    private bool playerAnswered;
    private bool questionSet;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAnswered && questionSet)
        {
            if (timerCounter <= 0)
            {
                timerText.text = "0";
                BombExplode();
            }
            else
            {

                timerCounter -= Time.deltaTime;
                timerText.text = Mathf.RoundToInt(timerCounter).ToString();
            }
        }
    }

    public void LoadQuestion(Question question, float timer, int questionNo)
    {
        timerCounter = timer;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;

        currentQuestion = question;
        questionNumberText.text = "Question\n" + questionNo.ToString();
        questionText.text = currentQuestion.questionText;
        questionID = currentQuestion.questionID;

        for (int i = 0; i < currentQuestion.answerText.Length; i++)
        {
            answerText[i].text = currentQuestion.answerText[i];
        }

        questionSet = true;

        bombAnimator.SetBool("Bomb Explode", false);
        playerAnimator.SetBool("Dead", false);
        bombAnimator.SetBool("Bomb Gone", false);
        playerAnimator.SetBool("Happy", false);
    }

    public void SelectAnswer(int option)
    {
        if (currentQuestion.answerOption != option)
        {
            BombExplode();
        } else
        {
            SuccessQuestion();
        }
        playerAnswered = true;
    }

    public void BombExplode()
    {
        bombAnimator.SetBool("Bomb Explode", true);
    }

    public void SuccessQuestion()
    {
        bombAnimator.SetBool("Bomb Gone", true);
    }

    public void ReturnToGame(bool success)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;

        GameManager.Instance.FinishQuestion(questionID, success);
    }
}
