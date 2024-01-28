using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    public GameObject[] objects;
    public Sprite[] sprites;
    void Start()
    {
        ActivateRandomFiveObjects();
    }

    void ActivateRandomFiveObjects()
    {
        int arrayLength = objects.Length;
        if (arrayLength < 5)
        {
            Debug.LogWarning("Not enough objects in the array to activate five.");
            return;
        }
        ShuffleArray();
        for (int i = 0; i < 5; i++)
        {
            if (objects[i] != null)
            {
                objects[i].SetActive(true);
                objects[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
            }
        }
    }

    void ShuffleArray()
    {
        int n = objects.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject temp = objects[k];
            objects[k] = objects[n];
            objects[n] = temp;
        }
    }

}
