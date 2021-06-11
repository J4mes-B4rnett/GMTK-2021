using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // A reference to the object we want to trigger
    [SerializeField]
    TriggeredObject triggeredObject;

    // If the object that we have collided with is NOT "terrain", then activate button.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Terrain"))
        {
            triggeredObject.triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Terrain"))
        {
            triggeredObject.triggered = false;
        }
    }
}
