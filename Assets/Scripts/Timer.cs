using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class Timer : MonoBehaviour
{
    [Range(60f, 300f)]
    public float timeRemaining = 180.0f; //3 minutes

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Image circleImage;

    private float currentTimer;

    void Start()
    {
        circleImage = GetComponent<Image>();
        currentTimer = timeRemaining;

        UpdateTimerText();
    }

    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            circleImage.fillAmount = currentTimer / timeRemaining;

            UpdateTimerText();
        }
        else
        {
            // on end
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTimer / 60);
        int seconds = Mathf.FloorToInt(currentTimer % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
