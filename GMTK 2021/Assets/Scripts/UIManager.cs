using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playButton;
    public string text1 = "Play";
    public string text2 = "Play Tutorial";

    public SceneTransitionController sTC;

    void Awake()
    {
        playButton.text = PlayerPrefs.GetInt("Level 1") == 1 ? text1 : text2;
    }

    public void LoadLevelMenu()
    {
        if (PlayerPrefs.GetInt("Level 1") == 1)
        {
            sTC.StartCoroutine(sTC.leaveScene("LevelManager"));
        }
        else
        {
            sTC.StartCoroutine(sTC.leaveScene("Level 1"));
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
