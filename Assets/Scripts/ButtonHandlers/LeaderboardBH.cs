using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardBH : MonoBehaviour
{
    public Button exitButton, goBackButton;

    // Start is called before the first frame update
    void Start()
    {
        goBackButton.onClick.AddListener(goBackMainMenu);
        exitButton.onClick.AddListener(exitGame);

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
}
