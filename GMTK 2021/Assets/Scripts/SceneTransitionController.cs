using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionController : MonoBehaviour
{
    public Animator anim;
    public string nextSceneName;
    [SerializeField] bool Outro;
    public KeyCode Restart;
    public bool canRestart;

    private void Awake()
    {
        PlayerPrefs.SetInt("Level 1", 1);
    }

    void Start()
    {
        Restart = KeyCode.R;
    }

    void Update()
    {
        if(Outro)
        {
            Outro = false;
            StartCoroutine(leaveScene(nextSceneName));
        }
        if(Input.GetKeyDown(Restart) && canRestart)
        {
            StartCoroutine(leaveScene(SceneManager.GetActiveScene().name));
        }

    }
    public IEnumerator leaveScene(string n)
    {
        anim.SetTrigger("Outro");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(n);
    }
    public void BackButton()
    {
        StartCoroutine(leaveScene("LevelManager"));
    }
}
