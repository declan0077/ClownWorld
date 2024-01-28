using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToClosestItem : MonoBehaviour
{
    public string targetTag = "YourItemTag"; // Set your item tag in the Inspector
    public float initialRotationOffset = -90f; // Adjust this value based on your specific needs

    // Update is called once per frame
    void Update()
    {
        RotateTowardsClosestItem();
    }

    void RotateTowardsClosestItem()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag(targetTag);

        if (items.Length > 0)
        {
            Transform closestItem = GetClosestItem(items);

            if (closestItem != null)
            {
                // Calculate the direction to the closest item
                Vector3 direction = closestItem.position - transform.position;

                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);

                // Apply initial rotation offset
                targetRotation *= Quaternion.Euler(0, 0, initialRotationOffset);

                // Set the rotation to look at the closest item
                transform.rotation = targetRotation;
            }
        }
    }

    Transform GetClosestItem(GameObject[] items)
    {
        Transform closestItem = null;
        float closestDistance = Mathf.Infinity;

        foreach (var item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestItem = item.transform;
            }
        }

        return closestItem;
    }
}
