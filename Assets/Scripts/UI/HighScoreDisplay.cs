using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private float verticalSpacing = 12f;
    private void Start()
    {
        List<LeaderboardEntry> highScores = LeaderboardManager.Instance.GetLeaderboardEntries();
        Debug.Log("High scores: " + highScores.Count);
        for (int i = 0; i < highScores.Count; i++)
        {
            GameObject scoreObject = Instantiate(scorePrefab, transform);
            foreach (Transform child in scoreObject.transform)
            {
                if (child.gameObject.name == "Name")
                {
                    Debug.Log("Name: " + highScores[i].playerName);
                    child.gameObject.GetComponent<Text>().text = highScores[i].playerName;
                }
                else if (child.gameObject.name == "Score")
                {
                    Debug.Log("Score: " + highScores[i].score);
                    child.gameObject.GetComponent<Text>().text = highScores[i].score.ToString();
                }
            }
            scoreObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -i * verticalSpacing);
        }
    }
}