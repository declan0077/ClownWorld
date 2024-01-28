using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
public class JsonCreate : MonoBehaviour
{
    public TMP_InputField nameofplayer;
    [System.Serializable]
    public class HighscoreEntry
    {
        public string playerName;
        public float playerScore;
    }

    [System.Serializable]
    public class HighscoreData
    {
        public List<HighscoreEntry> highscores = new List<HighscoreEntry>();
    }

    public SCR_EndScreen scrEndScreen;
    public string playerName;

    private string savePath;
    
    void Start()
    {
        savePath = "Assets/RuntimeData/highscores.json";
        LoadData();
    }

    void Update()
    {

        playerName = nameofplayer.text;
        if (Input.GetKeyDown(KeyCode.L))
        {
         
        }
    }

    public void saveData()
    {
        
            SaveData();
        LoadData();
    }

    void SaveData()
    {
        // Create a new entry with the current player name and score
        HighscoreEntry newEntry = new HighscoreEntry
        {
            playerName = playerName,
            playerScore = Mathf.Round(scrEndScreen.currentScore * 100) / 100f
        };

        // Load existing highscores
        HighscoreData highscoreData = new HighscoreData();
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            highscoreData = JsonUtility.FromJson<HighscoreData>(jsonData);
        }

        // Add the new entry to the highscores list
        highscoreData.highscores.Add(newEntry);

        // Sort the highscores by score in descending order
        highscoreData.highscores.Sort((a, b) => b.playerScore.CompareTo(a.playerScore));

        // Limit the highscores to a certain number (e.g., top 10)
        if (highscoreData.highscores.Count > 10)
        {
            highscoreData.highscores.RemoveAt(highscoreData.highscores.Count - 1);
        }

        // Save the updated highscores
        string updatedJsonData = JsonUtility.ToJson(highscoreData);
        File.WriteAllText(savePath, updatedJsonData);

        Debug.Log("Data saved!");
    }

    void LoadData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            HighscoreData highscoreData = JsonUtility.FromJson<HighscoreData>(jsonData);

            // Output highscores to the console
            foreach (var entry in highscoreData.highscores)
            {
                Debug.Log($"Player: {entry.playerName}, Score: {entry.playerScore}");
            }
        }
        else
        {
            Debug.Log("No saved highscores found.");
        }
    }
}
