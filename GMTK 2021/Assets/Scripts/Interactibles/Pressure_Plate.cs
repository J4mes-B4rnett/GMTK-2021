using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{
    // A reference to the object we want to trigger
    [SerializeField]
    TriggeredObject[] triggeredObject;

    // If the object that we have collided with is NOT "terrain", then activate button.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < triggeredObject.Length; i++)
            {
                triggeredObject[i].triggered = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < triggeredObject.Length; i++)
            {
                triggeredObject[i].triggered = false;
            }
        }
    }
}
