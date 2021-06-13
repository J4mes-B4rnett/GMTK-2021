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
        playButton.text = PlayerPrefs.GetInt("Tutorial") == 1 ? text1 : text2;
    }

    public void LoadLevelMenu()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            sTC.StartCoroutine(sTC.leaveScene("LevelManager"));
        }
        else
        {
            sTC.StartCoroutine(sTC.leaveScene("Tutorial"));
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
