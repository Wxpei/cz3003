using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingBH : MonoBehaviour
{
    public Button saveButton, backButton;
    public AudioMixer audioMixer;
    public Slider BGMslider;

    // Start is called before the first frame update
    void Start()
    {
        saveButton.onClick.AddListener(Save);
        backButton.onClick.AddListener(Back);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }


    void Save()
    {
        SceneManager.LoadScene("Profile");
    }

    void Back()
    {
        SceneManager.LoadScene("Main Menu (Student)");
        //SceneManager.LoadScene("Main Menu (Teacher)");
    }

}
