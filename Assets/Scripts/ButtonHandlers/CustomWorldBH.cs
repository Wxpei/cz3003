using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomWorldBH : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField room_id;
    public Button joinButton, createButton, goBackButton, exitButton;

    void Start()
    {
        createButton.onClick.AddListener(createWorld);
        joinButton.onClick.AddListener(joinWorld);

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
        SceneManager.LoadScene("Main Menu (" + SceneTransfer.accountType + ")");
    }

    void createWorld()
    {
        SceneManager.LoadScene("Create World (Teacher)");
    }
    void joinWorld()
    {
        // Add in code to check if the room_id/assignment_id is found in the question bank table
        int.TryParse(room_id.text, out int assign_id);
        SceneTransfer.assignment_id = assign_id;
        LoadSingleGame();
    }

    void LoadSingleGame()
    {
        int random = Random.Range(1, 4);

        SceneManager.LoadScene("SingleGame" + random);
    }
}
