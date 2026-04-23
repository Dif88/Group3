using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Degrees per second

    void Update()
    {
        // Rotate the object around its axes based on time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}