using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int currentScore;
    private int bestScore;
    public Text currentScoreText;
    public Text bestScoreText;
    public GameObject gameOverText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore",0);
        currentScoreText.text = $"Current: {currentScore}";
        bestScoreText.text = $"Best: {bestScore}";
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Debug.Log("Restart");
        gameOverText.SetActive(false);
        currentScore = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void AddScore(int i)
    {
        currentScore += i;
        currentScoreText.text = $"Current: {currentScore}";
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            bestScoreText.text = $"Best: {currentScore}";
        }
    }    
}
