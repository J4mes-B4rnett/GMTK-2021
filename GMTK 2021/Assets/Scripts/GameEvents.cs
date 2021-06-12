using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current; // Current Event Manager
    [field: SerializeField] public bool Activated { get; private set; } = false;

    private void Awake()
    {
        Current = this; // Assign Event Manager
    }

    public event Action onSceneTransition; // New Event
    public void BeginSceneTransition()
    {
        if (onSceneTransition != null) // Check Event Isn't Null
        {
            onSceneTransition(); // Invoke Event
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEvents.Current.BeginSceneTransition();
            Activated = true;
        }
    }
}
