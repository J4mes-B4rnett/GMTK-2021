﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine.Editor;
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
            GetComponent<BoxCollider2D>().enabled = true;
            for (var i = 0; i < boxCol.Length; i++)
            {
                boxCol[i].enabled = true;
            }
        }
        else // If we want to disable the colliders
        {
            GetComponent<BoxCollider2D>().enabled = false;
            for (var i = 0; i < boxCol.Length; i++)
            {
                boxCol[i].enabled = false;
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
}
