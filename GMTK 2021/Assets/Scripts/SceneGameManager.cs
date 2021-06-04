using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public void changeScenes(string name)
    {
        SceneManager.LoadScene(name);//load the scene
    }
}
