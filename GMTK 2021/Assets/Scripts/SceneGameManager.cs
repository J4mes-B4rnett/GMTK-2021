using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneGameManager : MonoBehaviour
{
    public GameObject transition;
    private Animator transitionAnim;

    private void Start()
    {
        //get access to the transition gameObject's animator component
        transition = GameObject.Find("Transition");
        transitionAnim = transition.GetComponent<Animator>();
    }

    private void Update()
    {
        //This section is just a way to show the transitions - it doesn't do much
        if (Input.anyKeyDown)
        {
            if(SceneManager.GetActiveScene().name == "TempScene1")
            {
                StartCoroutine(changeScenes("TempScene2"));
            }
            else
            {
                StartCoroutine(changeScenes("TempScene1"));
            }
        }
    }

    public IEnumerator changeScenes(string name)
    {
        transitionAnim.SetTrigger("EndScene");//start the end of scene animation
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);//end the scene
    }
}