using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class Timer : MonoBehaviour
{
    [Range(60f, 300f)]
    public float timeRemaining = 180.0f; //3 minutes
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Transform clockHand;
    
    private Image circleImage;

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

            UpdateTimerImage();
            UpdateTimerText();
        }
        else
        {
            // on end
        }
    }

    private void UpdateTimerImage()
    {
        circleImage.fillAmount = currentTimer / timeRemaining;
        //clockHand.Rotate(0.0f, 0.0f, (currentTimer / timeRemaining) * 360.0f, Space.Self);
        clockHand.rotation = Quaternion.Euler(0, 0, (currentTimer / timeRemaining) * 360.0f);
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTimer / 60);
        int seconds = Mathf.FloorToInt(currentTimer % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
