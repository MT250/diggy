using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static int score;
    public static int Score { get { return score; } set { score = value; } }

    public float timeCounter;
    public bool isGameOver;
    public bool isPaused;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    public static GameManager instance;

    private void Start()
    {
        instance = this;

        timeCounter = 1 * 60;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        timeCounter -= Time.deltaTime;
        timeText.text = timeCounter.ToString("0:00");

        if (timeCounter < 0) GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void AddScore(int _value)
    {
        Score += _value;
        scoreText.text = Score.ToString();
    }

    public void RestartGame()
    {
        Score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if(!isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
    GameManager() { }
}
