using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionController : MonoBehaviour
{
    public Animator anim;
    public string nextSceneName;
    [SerializeField] bool Outro;
    void Start()
    {
        
    }

    void Update()
    {
        if(Outro)
        {
            Outro = false;
            StartCoroutine(leaveScene());
        }
    }
    IEnumerator leaveScene()
    {
        anim.SetTrigger("Outro");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);

    }
}
