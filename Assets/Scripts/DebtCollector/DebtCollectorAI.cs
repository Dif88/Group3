using UnityEngine;
using UnityEngine.AI; // MUST HAVE THIS

[RequireComponent(typeof(NavMeshAgent))]
public class DebtCollectorChase : MonoBehaviour
{
    public Transform target;
    public float detectionRadius = 30f; // Give him a big eye-sight

    private NavMeshAgent agent;
    private Animator anim;
    private bool hasDetectedPlayer = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        
        // Match the high speed you wanted
        agent.speed = 4f; 
        agent.acceleration = 5f;
        agent.angularSpeed = 120f; // Helps him turn corners smoothly
    }

    void Start()
    {
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) target = playerObj.transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        float dist = Vector3.Distance(transform.position, target.position);

        if (dist <= detectionRadius) hasDetectedPlayer = true;
        
        if (hasDetectedPlayer)
        {
            // The magic line: tells the AI to find the path around obstacles
            agent.SetDestination(target.position);

            if (anim != null)
            {
                // If he is still far from the player, keep walking
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    anim.Play("walk1");
                }
                else
                {
                    anim.Play("Idle1");
                }
            }
        }
    }
}