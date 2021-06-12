using UnityEngine;

public class Platform : TriggeredObject
{
    // Update is called once per frame
    [SerializeField]
    Vector3 startPos; // Currently equal to -1, 0, 0
    [SerializeField]
    Vector3 endPos; // Currently equl to -1, 1, 0

    void Update()
    {
        Vector3 curPos = gameObject.transform.position;

        // If the button is triggered,
        // check to see if the platform is out of bounds
        // If it's within bounds, move towards the end position.
        if(triggered)
        {
            Debug.Log(name + " was triggered!");
            if ((curPos - endPos).magnitude >= .5f)
            {
                Debug.Log(name + " is moving.");
                gameObject.transform.position -= (curPos - endPos) * Time.deltaTime;
            }
        }
        else
        {
            if ((curPos - startPos).magnitude >= .05f)
            {
                Debug.Log(name + " is moving back.");
                gameObject.transform.position -= (curPos - startPos) * Time.deltaTime;
            }
        }
    }
}
