using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        Debug.Log("Register selected. Load Regsister Scene.");
        SceneManager.LoadScene("login");
    }

}
