using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyBH : MonoBehaviour
{
    public Button easyButton, normalButton, hardButton, exitButton, goBackButton;

    // Start is called before the first frame update
    void Start()
    {
        easyButton.onClick.AddListener(easyMode);
        normalButton.onClick.AddListener(normalMode);
        hardButton.onClick.AddListener(hardMode);

        goBackButton.onClick.AddListener(goBackSectionSelection);
        exitButton.onClick.AddListener(exitGame);

    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackSectionSelection()
    {
        SceneManager.LoadScene("Section");
    }
    void easyMode()
    {
        SceneTransfer.difficulty = "easy";

        LoadSingleGame();
    }

    void normalMode()
    {
        SceneTransfer.difficulty = "normal";

        LoadSingleGame();
    }

    void hardMode()
    {
        SceneTransfer.difficulty = "hard";

        LoadSingleGame();
    }

    void LoadSingleGame()
    {
        int random = Random.Range(1, 4);
        SceneTransfer.assignment_id = 0;

        SceneManager.LoadScene("SingleGame" + random);
    }
}
