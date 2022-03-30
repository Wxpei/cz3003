using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingBH : MonoBehaviour
{
    public Button backButton;
    public AudioMixer audioMixer;
    public Slider BGMslider;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    void Back()
    {
        SceneManager.LoadScene("Main Menu (" + SceneTransfer.accountType + ")");
        //SceneManager.LoadScene("Main Menu (Teacher)");
    }

}
