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
    public bool jump = false;
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

    // Jump Settings
    [Header("Jump")]
    
    public float jumpHeight;

    [SerializeField]
    private bool isTouchingGround;

    private Rigidbody2D _rb;
    
    public Animal animal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        if (animal == Animal.Rabbit)
        {
            fastMotion = true;
            jump = true;
            burrow = true;
        }
        else if (animal == Animal.Turtle)
        {
            slowMotion = true;
            shellPlatform = true;
        }
    }

    private void FixedUpdate()
    {
        _speedSetting = fastMotion ? speedFast : speedSlow;
        
        Vector2 input = new Vector2(Input.GetAxisRaw(("Horizontal")), 0f);

        // Moves the player
        _rb.velocity = new Vector2(input.x * (_speedSetting * Time.deltaTime * speedMultiplier), _rb.velocity.y);
        if (Input.GetButton("Jump") && jump && isTouchingGround)
        {
            if (isTouchingGround)
            {
                _rb.AddForce(Vector2.up * (Time.deltaTime * jumpHeight));
            }

            isTouchingGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }
}
