using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_EndScreen : MonoBehaviour
{
    [Header("Background image options")]
    [SerializeField] private Sprite backgroundImage_OnWin;
    [SerializeField] private Sprite backgroundImage_OnLose;

    [Header("Component reference")]
    [SerializeField] private Image backgroundComponent;
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private TextMeshProUGUI timerText;

    public float currentScore { get; private set; }
    public string playerName { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("Time");

        if (currentScore > 0f)
        {
            backgroundComponent.sprite = backgroundImage_OnWin;
            victoryText.text = "You Win!";
        } else
        {
            backgroundComponent.sprite = backgroundImage_OnLose;
            victoryText.text = "You Lose...";
        }
    }
}
