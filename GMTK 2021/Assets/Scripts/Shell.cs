using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public IEnumerator MoveToTarget(Vector2 target, float waitTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector2.Lerp(transform.position,target, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
