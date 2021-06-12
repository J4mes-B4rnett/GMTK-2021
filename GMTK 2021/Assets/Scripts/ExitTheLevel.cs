using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTheLevel : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Rabbit" && collision.gameObject.name == "Turtle")
        {
            Debug.Log("Exiting...");
        }
    }
}
