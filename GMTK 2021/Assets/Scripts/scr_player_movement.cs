using System;
using UnityEngine;

public class scr_player_movement : MonoBehaviour {

    //Movement
    [SerializeField] private float xSpeedLimit;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    public int movementDirection { get; private set; }

    //Physics stuff
    private new Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movementDirection = Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)) - Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow));
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