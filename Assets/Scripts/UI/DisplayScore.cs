using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Start() {
        _scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }
}
