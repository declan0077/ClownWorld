using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_EndScreen : MonoBehaviour
{
    [Header("Background image options")]
    [SerializeField] private Sprite backgroundImage_OnWin;
    [SerializeField] private Sprite backgroundImage_OnLose;

    [Header("Component reference")]
    [SerializeField] private Image backgroundComponent;

    private float currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("Time");

        if (currentScore > 0f)
        {
            backgroundComponent.sprite = backgroundImage_OnWin;
        } else
        {
            backgroundComponent.sprite = backgroundImage_OnLose;
        }
    }
}
