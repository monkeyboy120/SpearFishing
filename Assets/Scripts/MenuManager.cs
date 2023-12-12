using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign in Inspector
    private float timeRemaining = 30f;

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

        SceneManager.LoadScene("Final Screen");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}