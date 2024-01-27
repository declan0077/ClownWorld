using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwapper : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second

    private bool rotate = false;
    private float targetAngle = 0f;
    private Transform playerTransform;
    private GameObject player;
    private bool isrotating;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(isrotating == false)
            {
                playerTransform = collision.transform;
                player = collision.gameObject;
                targetAngle = playerTransform.eulerAngles.z + 180f;
                rotate = true;
                collision.gameObject.GetComponent<TransformJump>().gravityScale = 0;
                isrotating = true;
            }
        }
    }

    private void Update()
    {
        if (rotate)
        {
            float step = rotationSpeed * Time.deltaTime;
            float angle = Mathf.MoveTowardsAngle(playerTransform.eulerAngles.z, targetAngle, step);
            playerTransform.eulerAngles = new Vector3(0f, 0f, angle);
            float threshold = 1f;  // You can adjust this value as needed

            if (Mathf.Abs(angle - targetAngle) < threshold)
            {
                player.GetComponent<TransformJump>().gravityScale = 5;
                rotate = false;
                playerTransform.eulerAngles = new Vector3(0f, 0f, targetAngle);
                     isrotating = false;
            }
        }
    }

}
