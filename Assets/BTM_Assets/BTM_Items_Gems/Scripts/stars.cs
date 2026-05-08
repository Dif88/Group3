using UnityEngine;

public class stars : MonoBehaviour
{
    private bool collected = false;

    // We removed the Update() function so it stops rotating and moving up/down.

    void OnTriggerEnter(Collider other)
    {
        // Ensure your Player object is tagged "Player" in the Inspector!
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            CollectStar();
        }
    }

    void CollectStar()
    {
        Debug.Log("Star Collected!");
        // Add score logic here if needed: ScoreManager.instance.AddPoint();
        Destroy(gameObject); 
    }
}