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

    private void Update()
    {
        _speedSetting = fastMotion ? speedFast : speedSlow;
        
        Vector2 input = new Vector2(Input.GetAxisRaw(("Horizontal")), 0f);

        // Movement
        if (fastMotion)
        {
            float xSpeed = _rb.velocity.x;
            if (Mathf.Abs(speedFast) < 7f || input.x != Math.Sign(speedFast)) {
                _rb.velocity += Vector2.right * (1 * input.x); //acceleration
            }

            if (input.x >= 0.5f) {
                if (Mathf.Abs(speedFast) > 0) _rb.velocity -= Vector2.right * (1 * Math.Sign(speedFast)); //deceleration
                if (Mathf.Abs(speedFast) < 1) _rb.velocity = new Vector2(0, _rb.velocity.y); //rounding
            }
        }
        else if (slowMotion)
        {
            _rb.AddForce(input * (speedSlow * Time.deltaTime * (speedMultiplier * 175)));
            _rb.drag = 100f;
        }

        if (Input.GetButtonDown("Jump") && jump)
        {
            if (isTouchingGround)
            {
                _rb.velocity += Vector2.up * jumpHeight;
                
                if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y / 2);
                }
            }
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
