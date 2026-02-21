using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpVelocity = 7f;

    [Header("Ground")]
    public LayerMask groundLayer;        // set to your Ground layer (optional, fallback works)
    public float groundCheckExtra = 0.12f; // little extra distance past collider bottom

    private Rigidbody rb;
    private Collider col;

    private float moveX;
    private bool jumpQueued;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // Left/Right movement
        moveX = 0f;
        if (k.aKey.isPressed || k.leftArrowKey.isPressed) moveX -= 1f;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) moveX += 1f;

        // Jump (Space OR W OR Up Arrow)
        if (k.spaceKey.wasPressedThisFrame || k.wKey.wasPressedThisFrame || k.upArrowKey.wasPressedThisFrame)
            jumpQueued = true;
    }

    void FixedUpdate()
    {
        // Move
        Vector3 v = rb.linearVelocity;   // if this errors in your Unity version, use rb.velocity instead
        v.x = moveX * moveSpeed;
        rb.linearVelocity = v;

        // Jump
        if (jumpQueued)
        {
            if (IsGrounded())
            {
                v = rb.linearVelocity;
                v.y = jumpVelocity;
                rb.linearVelocity = v;
            }
            jumpQueued = false;
        }
    }

    bool IsGrounded()
    {
        // If you forgot to set the mask in Inspector, treat it as "everything"
        int mask = groundLayer.value;
        if (mask == 0) mask = ~0;

        Bounds b = col.bounds;
        float dist = b.extents.y + groundCheckExtra;

        // Ray from center straight down to just below collider bottom
        return Physics.Raycast(b.center, Vector3.down, dist, mask, QueryTriggerInteraction.Ignore);
    }

    void OnDrawGizmosSelected()
    {
        var c = GetComponent<Collider>();
        if (c == null) return;

        Bounds b = c.bounds;
        float dist = b.extents.y + groundCheckExtra;

        Gizmos.DrawLine(b.center, b.center + Vector3.down * dist);
    }
}