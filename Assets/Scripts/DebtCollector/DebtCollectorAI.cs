using UnityEngine;
using UnityEngine.AI;

public class DebtCollectorAI : MonoBehaviour
{
    [Header("Chase Settings")]
    public float detectionRange = 15f;
    public float attackRange = 1.8f;
    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 1.5f;

    [Header("References")]
    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;

    // Animator parameter names — match these to your DemonBoss4 controller
    private static readonly int SpeedParam   = Animator.StringToHash("Speed");
    private static readonly int AttackParam  = Animator.StringToHash("Attack");
    private static readonly int IsChasing    = Animator.StringToHash("IsChasing");

    private enum State { Idle, Chase, Attack }
    private State currentState = State.Idle;

    void Start()
    {
        agent    = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = true;
        agent.updatePosition = true;

        // Find player by tag
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
        else
            Debug.LogWarning("DebtCollector: No GameObject tagged 'Player' found!");
    }

    void Update()

    

    {
        if (player == null) return;

        float distToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        
        {
            case State.Idle:
                HandleIdle(distToPlayer);
                break;
            case State.Chase:
                HandleChase(distToPlayer);
                break;
            case State.Attack:
                HandleAttack(distToPlayer);
                break;
        }

        // Drive animator blend tree
        animator.SetFloat(SpeedParam, agent.velocity.magnitude);
    }

    void HandleIdle(float dist)
    {
        agent.isStopped = true;
        animator.SetBool(IsChasing, false);

        if (dist <= detectionRange)
        {
            currentState = State.Chase;
        }
    }

    void HandleChase(float dist)
    {
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
        animator.SetBool(IsChasing, true);

        if (dist <= attackRange)
        {
            currentState = State.Attack;
        }
        else if (dist > detectionRange)
        {
            currentState = State.Idle; // lost player
        }
    }

    void HandleAttack(float dist)
    {
        agent.isStopped = true;
        transform.LookAt(player); // always face player

        animator.SetTrigger(AttackParam);

        if (dist > attackRange)
        {
            currentState = State.Chase; // player escaped, resume chase
        }
    }

    // Visualize ranges in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
