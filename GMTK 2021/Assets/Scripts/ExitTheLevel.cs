using UnityEngine;

public class ExitTheLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Rabbit" && collision.gameObject.name == "Turtle")
        {
            Debug.Log("Exiting...");
        }
    }
}
