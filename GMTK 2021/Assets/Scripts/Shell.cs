using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] boxCol;

    public void ThrowShell(Vector2 target, float waitTime)
    {
        StartCoroutine(MoveToTarget(target, waitTime));
    }
    
    public IEnumerator MoveToTarget(Vector2 target, float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector2.Lerp(transform.position,target, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            
            for (var i = 0; i < boxCol.Length; i++)
            {
                boxCol[i].enabled = false;
            }
            
            yield return null;
        }

        for (var i = 0; i < boxCol.Length; i++)
        {
            boxCol[i].enabled = true;
        }
        yield return null;
    }
}
