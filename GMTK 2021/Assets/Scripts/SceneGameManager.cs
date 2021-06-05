using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneGameManager : MonoBehaviour
{
    public GameObject transition;
    private Animator _transitionAnim;
    private static readonly int EndScene = Animator.StringToHash("EndScene");

    private void Start()
    {
        // Get access to the transition gameObject's animator component
        transition = GameObject.Find("Transition");
        _transitionAnim = transition.GetComponent<Animator>();

        GameEvents.Current.onSceneTransition += BeginTransition; // Subscribe Event to Local Method
    }

    private void BeginTransition() // When Event Triggered
    {
        StartCoroutine(SceneManager.GetActiveScene().name == "TempScene1"
            ? ChangeScenes("TempScene2")
            : ChangeScenes("TempScene1"));
    }

    private IEnumerator ChangeScenes(string nameOfScene)
    {
        _transitionAnim.SetTrigger(EndScene);// Start the end of scene animation
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nameOfScene); // End the scene
    }
}