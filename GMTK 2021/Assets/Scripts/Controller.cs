using UnityEngine;
using System;

public class Controller : MonoBehaviour {

    //Horizontal Movement
    [SerializeField] private float xSpeedLimit;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    public int movementDirection { get; private set; }

    //Vertical Movement
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Vector2 groundCheckArea;
    private bool grounded;

    //Physics Stuff
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private LayerMask staticObjectLayer;

    private void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
        staticObjectLayer = LayerMask.GetMask("Static Object");
    }

    private void Update() {
        movementDirection = Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)) - Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow));

        if (GroundCheck() && Input.GetKeyDown(KeyCode.Z)) {
            rigidbody.velocity += Vector2.up * jumpSpeed;
        }
        if (Input.GetKeyUp(KeyCode.Z) && rigidbody.velocity.y > 0) rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y / 2);
    }

    private bool GroundCheck() {
        Vector2 bottomOrigin = collider.bounds.center - new Vector3(0, collider.bounds.extents.y);
        Collider2D hitObject = Physics2D.OverlapArea(bottomOrigin + groundCheckArea / 2, bottomOrigin - groundCheckArea / 2, staticObjectLayer);
        return hitObject != null;
    }

    private void FixedUpdate() {
        float xSpeed = rigidbody.velocity.x;
        if (Mathf.Abs(xSpeed) < xSpeedLimit || movementDirection != Math.Sign(xSpeed)) {
            rigidbody.velocity += Vector2.right * acceleration * movementDirection; //acceleration
        }

        if (movementDirection == 0) {
            if (Mathf.Abs(xSpeed) > 0) rigidbody.velocity -= Vector2.right * deceleration * Math.Sign(xSpeed); //deceleration
            if (Mathf.Abs(xSpeed) < deceleration) rigidbody.velocity = new Vector2(0, rigidbody.velocity.y); //rounding
        }
    }
}