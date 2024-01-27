using UnityEngine;

public class Parra : MonoBehaviour
{
    public float parallaxFactor = 1f; // Parallax factor for the background
    public float wrapThreshold = 10f; // Distance at which the background will wrap

    private float spriteWidth; // Width of the sprite
    private Vector3 initialPosition; // Initial position of the background

    void Start()
    {
        // Calculate the width of the sprite
        if (GetComponent<SpriteRenderer>() != null)
        {
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on the background.");
        }

        // Store the initial position of the background
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the parallax effect
        float parallax = Time.deltaTime * parallaxFactor;

        // Move the background based on the parallax effect
        transform.position = new Vector3(transform.position.x + parallax, transform.position.y, transform.position.z);

        // Check if the background needs to wrap around
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= spriteWidth + wrapThreshold)
        {
            // If the background has moved beyond the wrapThreshold, reset its position
            float offset = Mathf.Sign(parallax) * (spriteWidth + wrapThreshold);
            transform.position = new Vector3(initialPosition.x - offset, transform.position.y, transform.position.z);
        }
    }
}
