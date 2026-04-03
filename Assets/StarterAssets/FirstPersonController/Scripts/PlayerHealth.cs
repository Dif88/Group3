using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    // Sets the starting health to 3, matching your GDD
    public int maxHealth = 3; 
    
    // This MUST be named exactly CurrentHP so your HealthBarSpriteUI script can read it!
    public int CurrentHP { get; private set; }

    void Start()
    {
        CurrentHP = maxHealth; 
    }

    // Your DamageOnTouch script triggers this when the Debt Collector hits you
    public void TakeDamage(int damageAmount)
    {
        CurrentHP -= damageAmount;
        Debug.Log("Ouch! Current Health: " + CurrentHP);

        // Triggers the level restart if health hits 0
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("The Debt Collector got you! Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}