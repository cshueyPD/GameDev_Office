using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerInfo : MonoBehaviour
{
    [SerializeField] private Text _playerName;

    public void OnSetPlayerName() {
        ScoreManager.Instance.SetPlayerName(_playerName.text);
        LeaderboardManager.Instance.AddToLeaderboard(ScoreManager.Instance.GetPlayerName(), ScoreManager.Instance.GetScore());
    }
}
