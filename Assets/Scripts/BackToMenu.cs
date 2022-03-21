using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void goBackToMenu()
    {
        Debug.Log("Register selected. Load Regsister Scene.");
        SceneManager.LoadScene("login");
    }

}
