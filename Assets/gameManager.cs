
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    [SerializeField]
    private SceneChanger gameOver;

    [SerializeField]
    private SceneChanger highScore;

    [SerializeField]
    private SceneChanger scores;

    [SerializeField]
    private SceneChanger menu;

    [SerializeField]
    private SceneChanger lunchTime;

    public bool gameHasEnded = false;
    public bool canFire = true;
    public ProjectileType currentProjectile = ProjectileType.RED;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            if (LeaderboardManager.Instance.CheckIfHighScore(ScoreManager.Instance.GetScore()))
            {
                HighScore();
            }
            else
            {
                gameOver.SwitchToScene();
            }

            gameHasEnded =true;
            Debug.Log("Game Over");
        }

    }

    public void HighScore()
    {
        highScore.SwitchToScene();
    }


    public void Restart()
    {
        ScoreManager.Instance.SetScore(0);
        gameHasEnded = false;
        lunchTime.SwitchToScene();
    }

    public void Quit()
    {
        ScoreManager.Instance.SetScore(0);
        gameHasEnded = false;
        menu.SwitchToScene();
    }

    public void Scores()
    {
        scores.SwitchToScene();
    }
}

public enum ProjectileType
{
    RED = 0,
    GREEN,
    DONUT,
}
