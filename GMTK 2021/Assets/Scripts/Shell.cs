using System.Collections;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] boxCol; // All of the box colliders
    public bool enableColliders = false; // Should we enable the colliders?

    private Vector3 localTarget;

    void Awake()
    {
        boxCol = transform.GetChild(0).GetComponents<BoxCollider2D>(); // Assigns all of the colliders
    }

    void Update()
    {
        if (enableColliders) // If we want to enable the colliders
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            for (var i = 0; i < boxCol.Length; i++)
            {
                boxCol[i].isTrigger = false;
            }
        }
        else // If we want to disable the colliders
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            for (var i = 0; i < boxCol.Length; i++)
            {
                boxCol[i].isTrigger = true;
            }
        }

        if (localTarget == transform.position)
        {
            enableColliders = true;
        }
    }
    
    public void ThrowShell(Vector2 target, float waitTime) // Begin the coroutine
    {
        enableColliders = false; // Disable collision when the shell is moving
        StartCoroutine(MoveToTarget(target, waitTime));
        localTarget = target;
    }
    
    public IEnumerator MoveToTarget(Vector2 target, float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector2.Lerp(transform.position,target, elapsedTime / waitTime); // Lerp to the new target pos
            elapsedTime += Time.deltaTime; // Add to elapsed time
            yield return null; // Return
        }
        yield return null; // Return
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Rabbit" && collision.attachedRigidbody.velocity.magnitude <= 3)
        {
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);

        }
    }
}
