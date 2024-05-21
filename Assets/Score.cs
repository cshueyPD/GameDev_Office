using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        ScoreText.text = ScoreManager.Instance.GetScore().ToString();

    }
}
