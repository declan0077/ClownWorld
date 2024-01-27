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
    private Transform SpawnPos;
    private GroundCheck check;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }
   
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 0) * baseSpeed * Time.deltaTime;

        //Can you change this to a force based method
        transform.Translate(movement);

        if (Mathf.Approximately(horizontalInput, 0f))
        {
            rb.velocity = Vector2.zero;
           
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector2.zero;
            GetComponent<TransformJump>().enabled = true;
        }
 

        if (rb.velocity.magnitude > 1)
        {
            GetComponent<TransformJump>().enabled = true;
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
}
