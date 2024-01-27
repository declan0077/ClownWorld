using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterDoor : MonoBehaviour
{
    public Transform ExitDoor;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.transform.position = ExitDoor.position;
            }
        }
    }


}
