using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour {
    public static LeaderboardManager Instance { get; private set; }

    [SerializeField] private int NumberOfPlayersToLog = 5;
    private string jsonLeaderboardFileName = "leaderboard.json";
    private LeaderboardData leaderboardData = new LeaderboardData();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadLeaderboardData();
    }

    public void LoadLeaderboardData() {
        TextAsset jsonFile = Resources.Load<TextAsset>("leaderboard");
        if (jsonFile == null) {
            Debug.LogError("Leaderboard file not found");
            return;
        }
        leaderboardData = JsonUtility.FromJson<LeaderboardData>(jsonFile.text);
        Debug.Log("Leaderboard loaded: " + leaderboardData.entries.Count + " entries");
        // foreach (LeaderboardEntry entry in leaderboardData.entries) {
        //     Debug.Log(entry.playerName + ": " + entry.score);
        // }
    }

    private void SaveLeaderboardData() {
        string json = JsonUtility.ToJson(leaderboardData);
        string filePath = Application.dataPath + "/Resources/" + jsonLeaderboardFileName;
        if (!System.IO.File.Exists(filePath)) {
            System.IO.File.Create(filePath).Dispose();
        }
        System.IO.File.WriteAllText(filePath, json);
    }
    private void SortLeaderboard() {
        for (int i = 0; i < leaderboardData.entries.Count; i++) {
            for (int j = i + 1; j < leaderboardData.entries.Count; j++) {
                if (leaderboardData.entries[j].score > leaderboardData.entries[i].score) {
                    LeaderboardEntry temp = leaderboardData.entries[i];
                    leaderboardData.entries[i] = leaderboardData.entries[j];
                    leaderboardData.entries[j] = temp;
                }
            }
        }
    }

    public bool CheckIfHighScore(int score)
    {
        if (leaderboardData.entries.Count < NumberOfPlayersToLog)
        {
            return true;
        }
        return score > leaderboardData.entries[^1].score;
    }

    public void AddToLeaderboard(string playerName, int score)
    {
        LeaderboardEntry newEntry = new()
        {
            playerName = playerName,
            score = score
        };
        if(leaderboardData.entries.Count >= NumberOfPlayersToLog)
        {
            leaderboardData.entries.RemoveAt(leaderboardData.entries.Count - 1);
        
        }
        leaderboardData.entries.Add(newEntry);
        SortLeaderboard();
        SaveLeaderboardData();
    }

    public List<LeaderboardEntry> GetLeaderboardEntries()
    {
        return leaderboardData.entries;
    }
}

[System.Serializable]
public class LeaderboardEntry {
    public string playerName;
    public int score;
}

[System.Serializable]
public class LeaderboardData {
    public List<LeaderboardEntry> entries;
}