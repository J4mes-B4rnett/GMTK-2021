using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
    public bool shellActivated = false;
    public bool wallWalk = false;

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
    internal bool isTouchingGround; // This was private, changed to internal due to an inaccesible error in the animatorController.
    RaycastHit2D _hit; // Used to cast a ray downwards, detects ground.

    private Rigidbody2D _rb;
    
    // Shell Ability
    [Header("Shell")]
    [SerializeField] private GameObject shell;

    [SerializeField] public bool shellThrown { get; private set; }
    [SerializeField] private GameObject currentShell;
    
    // Animal Type
    [Header("Animal Type")]
    public Animal animal;
    
    // Direction
    private bool isFlipped;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        // Initializing our animals and their abilities based on their animal type (enum).
        if (animal == Animal.Rabbit) // Default Rabbit Traits
        {
            fastMotion = true;
            jump = true;
            burrow = true;
        }
        else if (animal == Animal.Turtle) // Default Turtle Traits
        {
            slowMotion = true;
            shellActivated = true;
            wallWalk = true;
        }
    }
    
    private void FixedUpdate()
    {
        _speedSetting = fastMotion ? speedFast : speedSlow; // Set the default speed setting
        
        Vector2 input = new Vector2(Input.GetAxisRaw(("Horizontal")), 0f); // Get raw inputs

        // Moves the player
        _rb.velocity = new Vector2(input.x * (_speedSetting * Time.deltaTime * speedMultiplier), _rb.velocity.y);
        
        if (Input.GetButton("Jump") && jump && isTouchingGround)
        {
            // Bitmask
            int playerMask = 1 << 9;

            // invert the bitmask
            playerMask = ~playerMask;
            
            // Casting our ray downwards (.55f, which is slightly bigger than the player)
            _hit = Physics2D.Raycast(transform.position, Vector2.down, .55f, playerMask);
            
            // As long as we are currently touching the ground, and our collider is NOT null, jump.
            if (isTouchingGround && _hit.collider != null)
            {
                _rb.AddForce(Vector2.up * (Time.deltaTime * jumpHeight));
            }

            isTouchingGround = false;
        }
    }

    private void Update()
    {
        isFlipped = _rb.velocity.x < 0 ? true : _rb.velocity.x > 0 ? false : isFlipped;
        GetComponent<SpriteRenderer>().flipX = isFlipped;
        
        if (shellActivated) // When the shell is activated
        {
            if (Input.GetKeyDown(KeyCode.Z)) // When Z Key is pressed
            {
                if (!shellThrown) // If the shell hasn't already been thrown
                {
                    var position = transform.position; // Create copy of the current pos
                    currentShell = Instantiate(shell, position, Quaternion.identity); // Instantiate the shell at this pos
                    if (isFlipped)
                    {
                        currentShell.GetComponent<Shell>().ThrowShell(new Vector2(position.x - 5, position.y - 3), 5f); // Set the target position for the shell to go to
                    }
                    else
                    {
                        currentShell.GetComponent<Shell>().ThrowShell(new Vector2(position.x + 5, position.y - 3), 5f); // Set the target position for the shell to go to
                    }

                    shellThrown = true; // Set the shell to thrown
                }
                else
                {
                    Destroy(currentShell.gameObject); // Destroy the old shell
                    shellThrown = false; // Set the shell to not thrown
                }
            }
        }
    }

    // Our ground detection functions
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }
}
