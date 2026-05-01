using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            // Chase the player
            agent.SetDestination(player.position);

            // If close enough, stop moving and attack
            if (distance <= agent.stoppingDistance)
            {
                GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
}