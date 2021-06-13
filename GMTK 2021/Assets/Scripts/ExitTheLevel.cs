using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitTheLevel : MonoBehaviour
{
    [SerializeField] bool rabbitOnFinish;
    [SerializeField] bool turtleOnFinish;
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Rabbit") rabbitOnFinish = false;
        if (collision.name == "Turtle") turtleOnFinish = false;
    }
}
