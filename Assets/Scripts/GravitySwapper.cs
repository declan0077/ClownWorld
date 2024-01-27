using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwapper : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second

    private bool rotate = false;
    private float targetAngle = 0f;
    private Transform playerTransform;
    public float angle = 180;
    private GameObject player;
    private bool isrotating;
    private bool Waitplease = false;
    private AudioSource AudioPlayer;
    public AudioClip Change;
    private void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerMovement>().emote.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                if (!Waitplease)
                {
                    StartCoroutine(Wait());

                    if (isrotating == false)
                    {

                        playerTransform = collision.transform;
                    
                        targetAngle = playerTransform.eulerAngles.z + angle;
                        rotate = true;
                        collision.gameObject.GetComponent<TransformJump>().gravityScale = 0;
                        isrotating = true;
                        player.GetComponent<BoxCollider2D>().enabled = false;
                        AudioPlayer.PlayOneShot(Change);
                        player.GetComponent<PlayerMovement>().baseSpeed = 0;
                        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                
                }
                else
                {
                    player.GetComponent<PlayerMovement>().emote.SetActive(false);
                }
            }
        }
        else
        {
            player.GetComponent<PlayerMovement>().emote.SetActive(false);
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
                playerTransform.rotation = Quaternion.Euler(0, 0, angle);
                player.GetComponent<TransformJump>().gravityScale = 5;
                player.GetComponent<BoxCollider2D>().enabled = true;
                rotate = false;
                isrotating = false;

                player.GetComponent<PlayerMovement>().baseSpeed = 6000;
            }
        }
    }
    IEnumerator Wait()
    {
        Waitplease = true;
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerMovement>().emote.SetActive(false);
        Waitplease = false;

    }
}