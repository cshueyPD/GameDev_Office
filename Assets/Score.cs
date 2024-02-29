
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
public Text ScoreText;
public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

public void UpdateScore()
{
score += 1;

}

}
