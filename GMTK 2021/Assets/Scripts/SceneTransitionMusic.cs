using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class SceneTransitionMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length>1)
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }
}
