using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    private AudioSource audioPlayer;
    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioPlayer.Play();
            var player = collision.gameObject;
            player.GetComponent<PlayerMovement>().Collected += 1;
            Destroy(this.gameObject,1 );
        }
        

    }
}
