using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float distanceToCheck = 0.5f;
    public bool isGrounded;
    public LayerMask Floor;
    public float coyoteTime = 0.2f;

    private void Update()
    {
        if (IsGrounded())
        {
            if (!isGrounded)
            {
                StartCoroutine(CoyoteTime());
            }
        }
        else
        {
            StopCoroutine(CoyoteTime());
        }
    }

    IEnumerator CoyoteTime()
    {
        isGrounded = true;
        yield return new WaitForSeconds(coyoteTime);
        isGrounded = false;
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck, Floor);
    }
}
