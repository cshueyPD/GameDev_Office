using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager Instance { get; private set; }

    private int currentScore = 0;
    private string currentPlayerName = "Player";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optionally: make this persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any additional instances
        }
    }

    public void SetScore(int score)
    {
        currentScore = score;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void SetPlayerName(string name)
    {
        currentPlayerName = name;
    }

    public string GetPlayerName()
    {
        return currentPlayerName;
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }
}