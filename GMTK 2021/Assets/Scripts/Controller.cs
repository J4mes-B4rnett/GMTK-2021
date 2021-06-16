﻿using System;
using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isActive;
    [Space]
    [Header("Ability Tracking")]
    
    // Rabbit Default Abilities
    public bool fastMotion = false;
    public bool jump = false;
    public bool burrow = false;

    // Turtle Default Abilities
    public bool slowMotion = false;
    public bool shellActivated = false;
    public bool wallWalk = false;
    public bool swimming = false;

    public AudioSource DeathSoundRabbit;
    public AudioSource DeathSoundTurtle;
    
    public AudioSource JumpTurtle;
    public AudioSource JumpRabbit;

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
    public PhysicsMaterial2D fictionPhys;
    public PhysicsMaterial2D slidePhys;

    // Jump Settings
    [Header("Jump")]
    
    public float jumpHeight;

    [SerializeField]
    internal bool isTouchingGround; // This was private, changed to internal due to an inaccesible error in the animatorController.
    RaycastHit2D _hitRight; // Used to cast a ray downwards, detects ground.
    RaycastHit2D _hitLeft;
    Collider2D col;

    private Rigidbody2D _rb;
    public Rigidbody2D _rbOther;
    
    // Shell Ability
    [Header("Shell")]
    [SerializeField] private GameObject shell;
    [SerializeField] public bool shellThrown { get; private set; }
    [SerializeField] private GameObject currentShell;
    [SerializeField] private bool canThrow = true;
    private bool shellForceFeedback;
    // Animal Type
    [Header("Animal Type")]
    public Animal animal;
    
    // Direction
    private bool isFlipped;

    public GameObject cardsCanvas;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        col = GetComponent<CapsuleCollider2D>();

        if(_rb.name == "Turtle")
        {
            _rbOther = GameObject.Find("Rabbit").GetComponent<Rigidbody2D>();
        }
        else if (_rb.name == "Rabbit")
        {
            _rbOther = GameObject.Find("Turtle").GetComponent<Rigidbody2D>();
        }
        
        
        
        // Initializing our animals and their abilities based on their animal type (enum).
        if (animal == Animal.Rabbit) // Default Rabbit Traits
        {
            fastMotion = true;
            jump = true;
            burrow = true;
            slowMotion = false;
            shellActivated = false;
            wallWalk = false;
            swimming = false;
        }
        else if (animal == Animal.Turtle) // Default Turtle Traits
        {
            slowMotion = true;
            shellActivated = true;
            wallWalk = true;
            fastMotion = false;
            burrow = false;
            swimming = true;
        }
    }
    
    private void FixedUpdate()
    {
        if (!isActive) { _rb.velocity = new Vector2(0, _rb.velocity.y); return; }
        _speedSetting = fastMotion ? speedFast : speedSlow; // Set the default speed setting
        
        Vector2 input = new Vector2(Input.GetAxisRaw(("Horizontal")), 0f); // Get raw inputs

        int playerMask = 1 << 9;

        // We want JUST the playerLayer this time.
        _hitRight = Physics2D.Raycast(transform.position + new Vector3(col.bounds.size.x / 2, -col.bounds.size.y / 2, 0),
            Vector2.down, .55f, playerMask);
        _hitLeft = Physics2D.Raycast(transform.position - new Vector3(col.bounds.size.x / 2, col.bounds.size.y / 2, 0),
            Vector2.down, .55f, playerMask);


        // Moves the player
        _rb.velocity = new Vector2(input.x * (_speedSetting * Time.deltaTime * speedMultiplier), _rb.velocity.y);

        
        // If we're on top of the player, and we move, turn friction "off".
        // If we stop moving while on the player, turn fricton "on".
        if (_hitRight.collider != null || _hitLeft.collider != null)
        {
            
            Debug.Log(_hitRight.collider.name);
            if ((_hitRight.collider.gameObject.name == "ButtonTrigger" || _hitLeft.collider.gameObject.name == "ButtonTrigger")
                && _rb.velocity.magnitude <= .5f && !Input.GetButton("Jump"))
            {
                _rb.sharedMaterial = fictionPhys;
                _rbOther.sharedMaterial = fictionPhys;
            }
            else if (_rb.velocity.magnitude >= .5f)
            {
                _rb.sharedMaterial = slidePhys;
                _rbOther.sharedMaterial = slidePhys;
            }
        }

        if (Input.GetButton("Jump") && jump && isTouchingGround)
        {
            // Bitmask
            int notPlayerMask = 1 << 9;
            // invert the bitmask
            notPlayerMask = ~notPlayerMask;

            // Casting our ray downwards (.55f, which is slightly bigger than the player)
            _hitRight = Physics2D.Raycast(transform.position + new Vector3(col.bounds.size.x / 2, -col.bounds.size.y / 2, 0),
                Vector2.down, .55f, notPlayerMask);
            _hitLeft = Physics2D.Raycast(transform.position - new Vector3(col.bounds.size.x / 2, col.bounds.size.y / 2, 0),
                Vector2.down, .55f, notPlayerMask);

            // As long as we are currently touching the ground, and our collider is NOT null, jump.
            if (isTouchingGround && (_hitRight.collider != null || _hitLeft.collider != null))
            {
                _rb.sharedMaterial = null;
                _rb.AddForce(Vector2.up * (Time.deltaTime * jumpHeight), ForceMode2D.Impulse);
            }

            isTouchingGround = false;

            if (animal == Animal.Rabbit)
            {
                if (!JumpRabbit.isPlaying)
                {
                    JumpRabbit.Play();
                }
            }
            else
            {
                if (!JumpTurtle.isPlaying)
                {
                    JumpTurtle.Play();
                }
            }
        }
        if (shellForceFeedback)
        {
            shellForceFeedback = false;
            _rb.AddForce(Vector2.up * 250);
        }
    }

    private void Update()
    {
        if (!isActive) { _rb.velocity = new Vector2(0, _rb.velocity.y); return; }
        isFlipped = _rb.velocity.x < -0.1 ? true : _rb.velocity.x > 0.1 ? false : isFlipped;
        GetComponent<SpriteRenderer>().flipX = isFlipped;

        if (shellActivated) // When the shell is activated
        {
            if (Input.GetKeyDown(KeyCode.Z) && canThrow) // When Z Key is pressed
            {
                if (!shellThrown) // If the shell hasn't already been thrown
                {
                    shellForceFeedback = true;
                    var position = transform.position; // Create copy of the current pos
                    currentShell = Instantiate(shell, position, Quaternion.identity); // Instantiate the shell at this pos
                    if (isFlipped)
                    {
                        currentShell.GetComponent<Shell>().ThrowShell(new Vector2(position.x - 5, position.y - .1f), 5f); // Set the target position for the shell to go to
                    }
                    else
                    {
                        currentShell.GetComponent<Shell>().ThrowShell(new Vector2(position.x + 5, position.y - .1f), 5f); // Set the target position for the shell to go to
                    }

                    canThrow = false;
                    StartCoroutine(Cooldown(.5f));
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

    private void OnCollisionEnter2D(Collision2D col)
    {

        // This is what allows the players to move when on top of each other.
        // FRICTION!
        if (col.gameObject.CompareTag("Player"))
        {
            col.rigidbody.sharedMaterial = fictionPhys;
            _rb.sharedMaterial = fictionPhys;
            isTouchingGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }


        // This code seems to cause problems, and it works without it sooooo
/*        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Goodbye 2!");
            col.rigidbody.sharedMaterial = null;
            _rb.sharedMaterial = null;
        }*/
    }

    IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canThrow = true;
    }
}
