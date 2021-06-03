using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current; // Current Event Manager
    void Awake()
    {
        current = this; // Assign Event Manager
    }

    public event Action onSceneTransition; // New Event
    public void BeginSceneTransition()
    {
        if (onSceneTransition != null) // Check Event Isn't Null
        {
            onSceneTransition(); // Invoke Event
        }
    }
}
