using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGrav : MonoBehaviour
{
   private Rigidbody2D RB;
    void Start()
    {
       RB = GetComponent<Rigidbody2D>();
        RB.gravityScale = -1;
    }

}
