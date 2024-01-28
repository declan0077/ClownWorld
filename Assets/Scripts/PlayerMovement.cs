using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerStats")]
    public float baseSpeed = 50f; 
    [Header("Private info")]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector3 SpawnPos;
    private GroundCheck check;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private SCR_HitStun hitStunScript;
    private bool hitStunned;
    public int Collected;
    [SerializeField]
    public GameObject emote;
    bool Upsidedown = false;
    bool isright = false;
    public float shootingForce = 50;
    public float raycastDistance = 50;

    public LayerMask LinerayMask;
    void Start()
    {
        SpawnPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hitStunScript = GetComponent<SCR_HitStun>();

        baseSpeed = 6000;
        hitStunned = false;
        StartCoroutine(WaitSpeed());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grav"))
        {
            emote.SetActive(true);
        }
        if (!hitStunned && hitStunScript != null && collision.gameObject.CompareTag("Obstacle"))
        {
            hitStunned = true;
            baseSpeed = 600;
            StartCoroutine(hitStunScript.HitStun());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grav"))
        {
            emote.SetActive(false);
        }
        if (hitStunned && hitStunScript != null && collision.gameObject.CompareTag("Obstacle"))
        {
            baseSpeed = 6000;
            hitStunned = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Strike");

            StartCoroutine(Wait());
        }
    
        if (Collected >= 5)
        {
            Debug.Log("GameOver");
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection;
        float threshold = 5f;  // You can adjust this value as needed

        if (Mathf.Abs(Quaternion.Angle(transform.rotation, Quaternion.Euler(0, 0, 180))) < threshold)
        {
            movementDirection = -transform.right;
            Upsidedown = true;
        }
        else
        {
            movementDirection = transform.right;
            Upsidedown = false;
        }

        // Apply movement in the determined direction
        rb.velocity = movementDirection * horizontalInput * baseSpeed * Time.deltaTime;


        //Can you change this to a force based method
        // transform.Translate(movement);

        if (Mathf.Approximately(horizontalInput, 0f))
        {
          //  rb.velocity = Vector2.zero;
           
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {

          //  rb.velocity = Vector2.zero;
            GetComponent<TransformJump>().enabled = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.position = SpawnPos;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isright = false;
            if (Upsidedown == true)
            {
                spriteRenderer.flipX = true;
            }
            else
            {

                spriteRenderer.flipX = false;
            }
        
        }

        // Check for left movement (A key)
        if (Input.GetKeyDown(KeyCode.A))
        {
            isright = true;
            if (Upsidedown == true)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        if (rb.velocity.magnitude > 1)
        {
            GetComponent<TransformJump>().enabled = true;
        }

    }
    IEnumerator Wait()
    {
  
        yield return new WaitForSeconds(0.5f);
        ShootRaycast();

    }
    IEnumerator WaitSpeed()
    {

        yield return new WaitForSeconds(0.6f);
        baseSpeed = 6001;

    }
    private void ShootRaycast()
    {
        if (Upsidedown)
        {
            Vector2 direction = isright ? transform.right : -transform.right;
            Vector2 endPoint = (Vector2)transform.position + direction * raycastDistance;
            RaycastHit2D linecastHit = Physics2D.Linecast(transform.position, endPoint, LinerayMask);

            // Debug.DrawLine(transform.position, endPoint, Color.red, 1f);

            if (linecastHit.collider != null)
            {
                Debug.Log(linecastHit.collider.gameObject);
                Rigidbody2D rigidbody2D = linecastHit.collider.GetComponent<Rigidbody2D>();

                if (rigidbody2D != null)
                {
                    Vector2 velocity = direction * shootingForce;
                    rigidbody2D.velocity = velocity;
                }
            }
        }
        else
        {

            Vector2 direction = isright ? -transform.right : transform.right;
            Vector2 endPoint = (Vector2)transform.position + direction * raycastDistance;
            RaycastHit2D linecastHit = Physics2D.Linecast(transform.position, endPoint, LinerayMask);

            // Debug.DrawLine(transform.position, endPoint, Color.red, 1f);

            if (linecastHit.collider != null)
            {
                Debug.Log(linecastHit.collider.gameObject);
                Rigidbody2D rigidbody2D = linecastHit.collider.GetComponent<Rigidbody2D>();

                if (rigidbody2D != null)
                {
                    Vector2 velocity = direction * shootingForce;
                    rigidbody2D.velocity = velocity;
                }
            }
        }
     
     
    }

public void restartLevel()
    {
       //GameOver stuff
    }
    //Spicy screen shake stuff If wanted, I can make wacky screen flippy stuff for chaos
    IEnumerator ScreenShake()
    {
        yield return new WaitForSeconds(0.25f);

        /*
        if (virtualCamera != null)
        {
            CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            if (noise != null)
            {
                noise.m_AmplitudeGain = 4.5f; // Adjust the amplitude of the shake
                noise.m_FrequencyGain = 1f; // Adjust the frequency of the shake
            }
        }

        // Wait for half a second before resetting the camera shake
        yield return new WaitForSeconds(0.25f);

        // Reset the camera shake to normal
        if (virtualCamera != null)
        {
            CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            if (noise != null)
            {
                noise.m_AmplitudeGain = 0f; // Reset amplitude to zero
                noise.m_FrequencyGain = 0f; // Reset frequency to zero
            }
        }
        */
       
    }

    void OnDrawGizmos()
    {
        // Get player direction based on Upsidedown status
        Vector2 direction = isright ? -transform.right : transform.right;

        // Define the end point for the linecast
        Vector2 endPoint = (Vector2)transform.position + direction * raycastDistance;

        // Set the Gizmo color
        Gizmos.color = Color.red;

        // Draw a line from the player's position to the end point
        Gizmos.DrawLine(transform.position, endPoint);
    }

}
