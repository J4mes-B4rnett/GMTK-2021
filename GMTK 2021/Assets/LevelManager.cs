using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    public SceneTransitionController sTC;

    void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            string levelName = "Level " + i.ToString();
            if (PlayerPrefs.GetInt(levelName) == 1)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
    
    public void ChangeLevel(int level)
    {
        sTC.StartCoroutine(sTC.leaveScene("Scene " + (level.ToString())));
    }
}
