using UnityEngine;

public class stars : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.StarsCollected();
            gameObject.SetActive(false);
        }
    }
}
