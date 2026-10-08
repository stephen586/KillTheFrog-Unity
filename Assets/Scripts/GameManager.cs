using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    public GameObject frog;

    public float gameTime = 30f;

    private float timeRemaining;
    private bool gameOver = false;

    private void Start()
    {
        timeRemaining = gameTime;

        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);

        // Hide Game Over UI when game starts
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

    private void GameOver()
    {
        gameOver = true;

        frog.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);

        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}