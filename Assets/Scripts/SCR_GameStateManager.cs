using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_GameStateManager : MonoBehaviour
{
    public static SCR_GameStateManager Instance { get; private set; }
    [SerializeField] private SCR_Timer timer;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void EndGame(bool winCondition)
    {
        if (winCondition && timer != null)
        {
            PlayerPrefs.SetFloat("Time", timer.timeRemaining - timer.currentTimer);
        } else
        {
            PlayerPrefs.SetFloat("Time", 0.0f);
        }

        SceneManager.LoadScene("SCN_EndScreen");
    }

}
