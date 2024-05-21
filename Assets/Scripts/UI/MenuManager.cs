using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Retry()
    {
        gameManager.Instance.Restart();
    }

    public void Quit()
    {
        gameManager.Instance.Quit();
    }

    public void Scores()
    {
        gameManager.Instance.Scores();
    }

    public void HighScore()
    {
        gameManager.Instance.HighScore();
    }
}