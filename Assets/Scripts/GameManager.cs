
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    public GameObject frog;

    public float gameTime = 30f;

    private float timeRemaining;
    private int score = 0;
    private bool gameOver = false;

    private void Start()
    {
        timeRemaining = gameTime;

        scoreText.text = "Score: 0";
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);

        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }

    private void Update()
    {
        if (!gameOver)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerText.text = "Time: 0";

                GameOver();
            }
            else
            {
                timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
            }
        }
    }

    public void AddScore()
    {
        if (gameOver) return;

        score++;
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        gameOver = true;

        // Stop all future frog spawning.
        FrogSpawner spawner = FindFirstObjectByType<FrogSpawner>();
        if (spawner != null)
        {
            spawner.CancelInvoke();
        }

        // Remove all frogs currently on screen.
        Frog[] frogs = FindObjectsByType<Frog>(FindObjectsSortMode.None);
        foreach (Frog currentFrog in frogs)
        {
            currentFrog.gameObject.SetActive(false);
        }

        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);

        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
