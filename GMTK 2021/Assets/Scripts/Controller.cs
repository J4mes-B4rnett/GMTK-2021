using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Controller : MonoBehaviour
{
    [Header("Ability Tracking")]
    
    // Rabbit Default Abilities
    public bool fastMotion = false;
    public bool doubleJump = false;
    public bool burrow = false;

    // Turtle Default Abilities
    public bool slowMotion = false;
    public bool shellPlatform = false;

    public enum Animal
    {
        Rabbit,
        Turtle
    };
    
    // Speed Settings
    [Header("Speed")]
    
    private float _speedSetting = 0f;
    
    [Range(0f, 10f)] public float speedSlow = 0f;
    [Range(5f, 15f)] public float speedFast = 0f;
    public float speedMultiplier = 25f;

    private Rigidbody2D _rb;
    
    public Animal animal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        if (animal == Animal.Rabbit)
        {
            fastMotion = true;
            doubleJump = true;
            burrow = true;
        }
        else if (animal == Animal.Turtle)
        {
            slowMotion = true;
            shellPlatform = true;
        }
    }

    private void Update()
    {
        _speedSetting = fastMotion ? speedFast : speedSlow;
        
        Vector2 input = new Vector2(Input.GetAxisRaw(("Horizontal")), Input.GetAxisRaw("Vertical"));

        if (fastMotion)
        {
            _rb.AddForce(input * (speedFast * Time.deltaTime * (speedMultiplier * 75)));
            _rb.drag = 25f;
        }
        else if (slowMotion)
        {
            _rb.AddForce(input * (speedSlow * Time.deltaTime * (speedMultiplier * 175)));
            _rb.drag = 100f;
        }
    }
}
