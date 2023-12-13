using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign in Inspector
    public TextMeshProUGUI scoreText;
    private float timeRemaining = 30f;
    private int currentScore = 0;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    void EndGame()
    {
        MainManager.Instance.UpdateHighScore(currentScore);
        SceneManager.LoadScene("Final Screen");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    void UpdateScore(int scoreToAdd) {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }
}