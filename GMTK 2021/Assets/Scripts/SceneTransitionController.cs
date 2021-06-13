using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionController : MonoBehaviour
{
    public Animator anim;
    public string nextSceneName;
    [SerializeField] bool Outro;
    public KeyCode Restart;
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
        if(Input.GetKeyDown(Restart))
        {
            StartCoroutine(leaveScene(SceneManager.GetActiveScene().name));
        }

    }
    IEnumerator leaveScene(string n)
    {
        anim.SetTrigger("Outro");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(n);

    }
}
