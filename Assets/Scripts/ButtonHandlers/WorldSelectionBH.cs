using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldSelectionBH : MonoBehaviour
{
    public Button exitButton, mathButton, goBackButton, physicsButton, chemistryButton, biologyButton, historyButton, socialStudiesButton, geographyyButton; 

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        mathButton.onClick.AddListener(mathMode);
        physicsButton.onClick.AddListener(physicsMode); 
        chemistryButton.onClick.AddListener(chemistryMode);
        biologyButton.onClick.AddListener(biologyMode);
        historyButton.onClick.AddListener(historyMode);
        socialStudiesButton.onClick.AddListener(socialStudiesMode);
        geographyyButton.onClick.AddListener(geographyyMode);
        
        goBackButton.onClick.AddListener(goBackMainMenuStudent);
        exitButton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackMainMenuStudent()
    {
        SceneManager.LoadScene("Main Menu (Student)");
    }

    void mathMode()
    {
        Debug.Log("Mathematics World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void physicsMode()
    {
        Debug.Log("Physics World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void chemistryMode()
    {
        Debug.Log("Chemistry World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void biologyMode()
    {
        Debug.Log("Biology World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void historyMode()
    {
        Debug.Log("History World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void socialStudiesMode()
    {
        Debug.Log("Social Studies World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }

    void geographyyMode()
    {
        Debug.Log("Geography World selected. Load Section Scene.");
        SceneManager.LoadScene("Difficulty");
    }
}
