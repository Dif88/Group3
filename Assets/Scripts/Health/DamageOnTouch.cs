using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        // By adding "InParent", it will search up your player's hierarchy until it finds the health script!
        var health = collision.collider.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Same here!
        var health = other.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}