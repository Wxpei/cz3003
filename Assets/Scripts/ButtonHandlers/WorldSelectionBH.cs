using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldSelectionBH : MonoBehaviour
{
    public Button exitButton, mathButton, goBackButton, scienceButton, historyButton, socialStudiesButton, geographyyButton; 

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        mathButton.onClick.AddListener(mathMode);
        scienceButton.onClick.AddListener(scienceMode); 
        historyButton.onClick.AddListener(historyMode);
        socialStudiesButton.onClick.AddListener(socialStudiesMode);
        geographyyButton.onClick.AddListener(geographyMode);
        
        goBackButton.onClick.AddListener(goBackAvatarSection);
        exitButton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Debug.Log("Exit selected. Quit Application.");
        Application.Quit();
    }

    void goBackAvatarSection()
    {
        SceneManager.LoadScene("AvatarSelection");
    }

    void mathMode()
    {
        Debug.Log("Mathematics World selected. Load Section Scene.");

        SceneTransfer.subject = "math";

        SceneManager.LoadScene("Section");
    }

    void scienceMode()
    {
        Debug.Log("Science World selected. Load Section Scene.");

        SceneTransfer.subject = "science";

        SceneManager.LoadScene("Section");
    }

    void historyMode()
    {
        Debug.Log("History World selected. Load Section Scene.");

        SceneTransfer.subject = "history";

        SceneManager.LoadScene("Section");
    }

    void socialStudiesMode()
    {
        Debug.Log("Social Studies World selected. Load Section Scene.");

        SceneTransfer.subject = "scoialstudies";

        SceneManager.LoadScene("Section");
    }

    void geographyMode()
    {
        Debug.Log("Geography World selected. Load Section Scene.");

        SceneTransfer.subject = "geography";

        SceneManager.LoadScene("Section");
    }
}
