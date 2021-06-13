using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    public SceneTransitionController sTC;

    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("Level 1", 0);
            PlayerPrefs.SetInt("Level 2", 0);
            PlayerPrefs.SetInt("Level 3", 0);
        }
        
        for (int i = 0; i < buttons.Length; i++)
        {
            string levelName = "Level " + i.ToString();
            if (PlayerPrefs.GetInt(levelName) == 1)
            {
                buttons[i].interactable = false;
            }
            else
            {
                buttons[i].interactable = true;
            }
        }
    }
    
    public void ChangeLevel(int level)
    {
        sTC.StartCoroutine(sTC.leaveScene("Scene " + (level.ToString())));
    }
}
