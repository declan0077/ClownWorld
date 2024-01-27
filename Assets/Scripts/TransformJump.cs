using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransformJump : MonoBehaviour
{
    public GroundCheck groundCheck;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;
   
    Vector3 originalScaleAll; // Variable to store the original scale
    void Start()
    {
    
        originalScaleAll = transform.localScale; // Store the original scale
    }

    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;

        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            velocity = jumpForce;
            groundCheck.isGrounded = true;
            // Apply squash-and-stretch effect
            StartCoroutine(SquashAndStretch());
        }
        */
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
    IEnumerator SquashAndStretch()
    {
        float duration = 0.2f; // Duration of the effect
        float squashFactor = 1.4f; // Adjust this value for the squash effect along the length
        float stretchFactor = 0.5f; // Adjust this value for the stretch effect along the width

        Vector3 originalScale = originalScaleAll;

        // Calculate separate scales for length (Y-axis) and width (X-axis)
        Vector3 squashScale = new Vector3(originalScale.x * squashFactor, originalScale.y, originalScale.z);
        Vector3 stretchScale = new Vector3(originalScale.x * stretchFactor, originalScale.y, originalScale.z);

        float timer = 0f;

        while (timer < duration)
        {
            // Interpolate between squash and stretch scales based on time for length
            float t = timer / duration;
            transform.localScale = Vector3.Lerp(originalScale, squashScale, t);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f; // Reset timer for the second stretch effect

        while (timer < duration)
        {
            // Interpolate between squash and stretch scales based on time for width
            float t = timer / duration;
            transform.localScale = Vector3.Lerp(squashScale, stretchScale, t);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure to set the final scale to the original scale
        transform.localScale = originalScale;
    }

}