using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
   
    void Awake()
    {
        PlayerPrefs.SetInt("Level 1", 0);
        PlayerPrefs.SetInt("Level 2", 0);
        PlayerPrefs.SetInt("Level 3", 0);
        PlayerPrefs.SetInt("Level 4", 0);
        PlayerPrefs.SetInt("Level 5", 0);
        PlayerPrefs.SetInt("Level 6", 0);
        PlayerPrefs.SetInt("Level 7", 0);
        PlayerPrefs.SetInt("Level 8", 0);
        PlayerPrefs.SetInt("Level 9", 0);
        PlayerPrefs.SetInt("Level 10", 0);
        
        Debug.Log(PlayerPrefs.GetInt("Level 1"));
        Debug.Log(PlayerPrefs.GetInt("Level 2"));
        Debug.Log(PlayerPrefs.GetInt("Level 3"));
        Debug.Log(PlayerPrefs.GetInt("Level 4"));
        Debug.Log(PlayerPrefs.GetInt("Level 5"));
        Debug.Log(PlayerPrefs.GetInt("Level 6"));
        Debug.Log(PlayerPrefs.GetInt("Level 7"));
        Debug.Log(PlayerPrefs.GetInt("Level 8"));
        Debug.Log(PlayerPrefs.GetInt("Level 9"));
        Debug.Log(PlayerPrefs.GetInt("Level 10"));
        
    }
}
