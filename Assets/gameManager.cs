
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int enemyKillCount = 0;

    bool gameHasEnded = false;
  public  void EndGame()
    {
    if (gameHasEnded == false)
        {
            gameHasEnded =true;
            Debug.Log("Game Over");
            Invoke("Restart",1f);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    public void enemyKillCounter()
    {

    enemyKillCount += 1;

    }
}
