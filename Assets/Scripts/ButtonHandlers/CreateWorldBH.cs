using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateWorldBH : MonoBehaviour
{
    // Start is called before the first frame update
    public Button goBackButton, exitButton;

    void Start()
    {
        goBackButton.onClick.AddListener(goBackMainMenu);
        exitButton.onClick.AddListener(exitGame);

        // Set the assignment_id for the GameManager to retreive questions | Default is 0
    }
    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenu()
    {
        SceneManager.LoadScene("MultiplayerJoinWorld");
    }
}
