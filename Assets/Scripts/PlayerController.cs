using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpVelocity = 7f;

    [Header("Ground")]
    public LayerMask groundLayer;     // set this to Ground layer
    public float groundRadius = 0.2f; // how forgiving grounding is

    private Rigidbody rb;
    private Collider col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        rb.freezeRotation = true; // stop capsule tipping over
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // Left/Right movement (X axis)
        float x = 0f;
        if (k.aKey.isPressed || k.leftArrowKey.isPressed) x -= 1f;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) x += 1f;

        Vector3 v = rb.linearVelocity;
        v.x = x * moveSpeed;
        rb.linearVelocity = v;

        // Jump
        if (k.spaceKey.wasPressedThisFrame)
        {
            v = rb.linearVelocity;
            v.y = jumpVelocity;
            rb.linearVelocity = v;


            
        }


    }

    bool IsGrounded()
    {
        // Check a small sphere at the bottom of the player's collider
        Bounds b = col.bounds;
        Vector3 p = new Vector3(b.center.x, b.min.y + 0.05f, b.center.z);

        return Physics.CheckSphere(p, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }

    void OnDrawGizmosSelected()
    {
        // Draw where we're checking for ground (helps debug)
        var c = GetComponent<Collider>();
        if (c == null) return;

        Bounds b = c.bounds;
        Vector3 p = new Vector3(b.center.x, b.min.y + 0.05f, b.center.z);

        Gizmos.DrawWireSphere(p, groundRadius);
    }
}