using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class scr_player_jump : MonoBehaviour {

    //Jump
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private Vector2 groundCheckArea;
    public bool grounded { get; private set; }

    //Physics Stuff
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private LayerMask staticObjectLayer;

    private bool GroundCheck() {
        Vector2 bottomOrigin = collider.bounds.center - new Vector3(0, collider.bounds.extents.y);
        Collider2D hitObject = Physics2D.OverlapArea(bottomOrigin + groundCheckArea / 2, bottomOrigin - groundCheckArea / 2, staticObjectLayer);
        return hitObject != null;
    }

    private void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
        staticObjectLayer = LayerMask.GetMask("Static Object");
    }

    private void FixedUpdate() {
        grounded = GroundCheck();
        if (!grounded) rigidbody.velocity += Vector2.down * gravity;
    }

    private void Update() {
        if (grounded && Input.GetKeyDown(KeyCode.Z)) {
            rigidbody.velocity += Vector2.up * jumpSpeed;
        }
        if (Input.GetKeyUp(KeyCode.Z) && rigidbody.velocity.y > 0) rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y / 2);
    }

    private void OnDrawGizmosSelected() {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(collider.bounds.center - new Vector3(0, collider.bounds.extents.y), groundCheckArea);
    }
}