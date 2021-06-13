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
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Rabbit") rabbitOnFinish = false;
        if (collision.name == "Turtle") turtleOnFinish = false;
    }
}
