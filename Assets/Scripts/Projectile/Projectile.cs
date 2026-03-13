using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 20f;
    public float lifeTime = 5f;
    public int damage = 10;

    [Header("Effects")]
    public GameObject impactEffect;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Give the bullet an initial push
        rb.linearVelocity = transform.forward * speed;

        // Ensure the bullet doesn't live forever if it misses
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Add logic here for what the bullet hits
        Debug.Log("Hit: " + collision.gameObject.name);

        // Spawn impact particles if you have them
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        // Clean up the projectile
        Destroy(gameObject);
    }
}

