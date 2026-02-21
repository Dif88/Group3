using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DebtCollectorChase : MonoBehaviour
{
    public Transform target;          // drag Player here OR auto-find by tag
    public float moveSpeed = 4f;
    public float stopDistance = 1.5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Optional: keep enemy from tipping over
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Start()
    {
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) target = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 toTarget = target.position - transform.position;

        // Ignore vertical difference (prevents weird flying/chasing up/down slopes)
        toTarget.y = 0f;

        float dist = toTarget.magnitude;
        if (dist <= stopDistance) return;

        Vector3 dir = toTarget.normalized;
        Vector3 nextPos = rb.position + dir * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(nextPos);

        // Optional: face the player
        if (dir.sqrMagnitude > 0.001f)
            transform.forward = dir;
    }
}