using UnityEngine;

public class Water : MonoBehaviour
{

    [SerializeField] Rigidbody2D character;
    public float pushForce;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(character)
        {
            character.AddForce(Vector2.up * pushForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Turtle"|| collision.gameObject.name == "Rabbit")
        {
            if(collision.GetComponent<Controller>().swimming)
            {
                character = collision.GetComponent<Rigidbody2D>();
            } else
            {
                GameObject.Find("Game Manager").GetComponent<SceneTransitionController>().RestartButton();
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Turtle" || collision.gameObject.name == "Rabbit")
        {
            if (collision.GetComponent<Controller>().swimming)
            {
                character = null;
            }
        }
    }
}
