using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class LeaderBoardDisplay : MonoBehaviour
{
    public TMP_Text leaderboardText; // Reference to the Text component for displaying leaderboard

    private string savePath;

    void Start()
    {
        savePath = "Assets/RuntimeData/highscores.json";
        DisplayLeaderboard();
    }
    private void Update()
    {
        DisplayLeaderboard();
    }
    void DisplayLeaderboard()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            JsonCreate.HighscoreData highscoreData = JsonUtility.FromJson<JsonCreate.HighscoreData>(jsonData);

            // Sort highscores by playerScore in ascending order
            highscoreData.highscores.Sort((a, b) => a.playerScore.CompareTo(b.playerScore));

            // Clear previous leaderboard text
            leaderboardText.text = "";

            // Display highscores in the Text component
            foreach (var entry in highscoreData.highscores)
            {
                leaderboardText.text += $"AKA: {entry.playerName}, Time: {entry.playerScore}\n";
            }
        }
        else
        {
            leaderboardText.text = "No saved highscores found.";
        }
    }

}
