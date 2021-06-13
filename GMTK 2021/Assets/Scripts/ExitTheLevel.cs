using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitTheLevel : MonoBehaviour
{
    [SerializeField] bool rabbitOnFinish;
    [SerializeField] bool turtleOnFinish;
    public GameObject winScreen;
    [SerializeField] GameObject gameManager;
    private void Start()
    {
        winScreen = GameObject.Find("Win screen");
        gameManager = GameObject.Find("Game Manager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Rabbit") rabbitOnFinish = true;
        if (collision.name == "Turtle") turtleOnFinish = true;
        if(rabbitOnFinish && turtleOnFinish)
        {
            Debug.Log("Finished");
            string name = "Level " + (int.Parse(SceneManager.GetActiveScene().name.Split(' ')[1]) + 1);
            PlayerPrefs.SetInt(name, 1);
            Debug.Log(name + "   " + PlayerPrefs.GetInt(name));
            winScreen.transform.Find("Image").GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Points: " + gameManager.GetComponent<PointSystem>().currentValue;
            winScreen.GetComponent<Animator>().SetTrigger("Win");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Rabbit") rabbitOnFinish = false;
        if (collision.name == "Turtle") turtleOnFinish = false;
    }
}
