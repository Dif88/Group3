using UnityEngine;

public class stars : MonoBehaviour
{
    private bool collected = false;

    // We removed Update() entirely so it stays perfectly still

    void OnTriggerEnter(Collider other)
    {
        // Only collect if the object hitting the star is the Player
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            CollectStar();
        }
    }

    void CollectStar()
    {
        // You can add your score logic here later!
        Debug.Log("Star Collected!"); 
        Destroy(gameObject); 
    }
}