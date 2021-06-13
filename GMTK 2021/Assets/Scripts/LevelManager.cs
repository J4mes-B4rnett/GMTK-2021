using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject UICanvas;
    public List<Button> buttons;
    public SceneTransitionController sTC;

    private void Awake()
    {
    }
    private void Start()
    {
        getButtons();
        List<bool> values = new List<bool>() {}; 
        for (int i = 1; i <= 10; i++)
        {
            values.Add(PlayerPrefs.GetInt("Level " + i) == 1 ? true : false);
        }
        refreshInteractability(values);
    }
    public void Update()
    {

    }

    void getButtons()
    {
        for (int i = 0; i < UICanvas.transform.childCount; i++)
        {
            GameObject level = UICanvas.transform.GetChild(i).gameObject;
            if (level.name.Contains("Level")) buttons.Add(level.GetComponent<Button>());
        }
    }
    
    public void ChangeLevel(int level)
    {
        sTC.StartCoroutine(sTC.leaveScene("Level " + (level.ToString())));
    }

    void refreshInteractability(List<bool> interactability)
    {
        buttons[0].interactable = true;
        for (int i = 0; i < buttons.Count; i++)
        {
            if(i < interactability.Count)
            {
                buttons[i].interactable = interactability[i];
            } else
            {
                buttons[i].interactable = false;
            }
        }
    }
}
