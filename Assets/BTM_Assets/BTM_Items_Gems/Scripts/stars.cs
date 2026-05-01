using UnityEngine;

public class stars : MonoBehaviour
{
    [Header("Collection Effect")]
    public float spinSpeed = 180f;        // Optional: spin before collect
    public bool spinOnCollect = true;

    private bool collected = false;

    void Update()
    {
        // Optional: make it spin to look collectible
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Make sure only the player collects it
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            CollectStar();
        }
    }

    void CollectStar()
    {
        // TODO: Add to score, play sound, etc.
        // AudioSource.PlayClipAtPoint(collectSound, transform.position);

        Destroy(gameObject); // Vanishes on collect
    }
}
