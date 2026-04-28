using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DebtCollectorChase : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 4f;
    public float stopDistance = 1.5f;
    public float detectionRadius = 20f;

    private Rigidbody rb;
    private Animator anim; // 1. Add this
    private bool hasDetectedPlayer = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        
        // 2. Grab the Animator from the child (the skin)
        anim = GetComponentInChildren<Animator>(); 
    }

    // ... (Keep your Start function the same)

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0f;
        float dist = toTarget.magnitude;

        if (dist <= detectionRadius) hasDetectedPlayer = true;
        if (!hasDetectedPlayer) return;

        // 3. Logic for Animation
        if (dist <= stopDistance) 
        {
            if (anim != null) anim.SetFloat("Speed", 0f); // Stop walking
            return;
        }

        Vector3 dir = toTarget.normalized;
        Vector3 nextPos = rb.position + dir * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPos);

        if (dir.sqrMagnitude > 0.001f)
        {
            transform.forward = dir;
            if (anim != null) anim.SetFloat("Speed", moveSpeed); // 4. Start walking
        }
    }
}