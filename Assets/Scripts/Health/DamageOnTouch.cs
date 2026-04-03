using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 1;
    
    [Header("Cooldown Settings")]
    public float damageCooldown = 1f; // The 0.5 second pause!
    private float nextDamageTime = 0f;  // Keeps track of the timer

    // Triggers when they first touch
    private void OnTriggerEnter(Collider other)
    {
        TryToDamage(other);
    }

    // Triggers continuously while they are still touching
    private void OnTriggerStay(Collider other)
    {
        TryToDamage(other);
    }

    // A helper method so we don't have to write the same code twice
    private void TryToDamage(Collider target)
    {
        // Check if the current time has passed our cooldown timer
        if (Time.time >= nextDamageTime)
        {
            // Search for the health script
            var health = target.GetComponentInParent<PlayerHealth>();
            
            if (health != null)
            {
                health.TakeDamage(damage);
                
                // Set the timer so we can't take damage again for 0.5 seconds
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}