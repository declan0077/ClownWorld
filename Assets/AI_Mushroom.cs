using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Mushroom : MonoBehaviour
{
    // public GameObject mushroom;

    public Transform[] Points;
    public GameObject rWall;
    public GameObject lWall;
    public GameObject roof;
    public GameObject floor;

    public float speed;

    private float distance;

   public bool movingRight;
   public bool movingUp;
    public bool FinishedLR;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public List<Transform> points; // List of points to move to
   
    private int currentPointIndex = 0; // Index of the current point

    void Update()
    {
        // If there are points to move to
        if (points.Count > 0)
        {
            // Move towards the current point
            Transform currentPoint = points[currentPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

            // If the object has reached the current point
            if (Vector3.Distance(transform.position, currentPoint.position) < 0.1f)
            {
                // Move to the next point
                currentPointIndex = (currentPointIndex + 1) % points.Count;
            }
        }
        /*
       // Update is called once per frame
       void Update()
   {

       foreach (var p in Points) 
       {
        //move to each point

       }
       //   distance = Vector2.Distance(transform.position, rWall.transform.position);
       //     Vector2 direction = rWall.transform.position - transform.position;

       if (FinishedLR == false)
       {
           if (movingRight == true)
           {
               transform.position = Vector2.MoveTowards(this.transform.position, rWall.transform.position, speed * Time.deltaTime);
               if (transform.position == rWall.transform.position)
               {
                   movingRight = false;

               }
           }
           else
           {
               transform.position = Vector2.MoveTowards(this.transform.position, lWall.transform.position, speed * Time.deltaTime);
               if (transform.position == lWall.transform.position)
               {
                   movingRight = true;

               }
           }

       }
       else
       {
           if (movingUp == true)
           {
               transform.position = Vector2.MoveTowards(this.transform.position, floor.transform.position, speed * Time.deltaTime);
               if (transform.position == floor.transform.position)
               {
                   movingUp = false;
               }
           }
           else
           {
               transform.position = Vector2.MoveTowards(this.transform.position, roof.transform.position, speed * Time.deltaTime);
               if (transform.position == roof.transform.position)
               {
                   movingUp = true;
                   FinishedLR = false;
               }
           }
       }
      */

    }
}
