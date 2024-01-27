using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float distanceToCheck = 0.5f;
    public bool isGrounded;
    public LayerMask Floor;
    //Ignore
    public float coyoteTime = 0.2f;


    public void Update()
    {
        isGrounded = IsGrounded();


    }

    bool IsGrounded()
    {
        Vector2 rayDirection = transform.TransformDirection(Vector2.down);
        return Physics2D.Raycast(transform.position, rayDirection, distanceToCheck, Floor);
    }

}
