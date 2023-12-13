using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Image oxygenBar;
    public float maxOxygen = 30f;
    private float currentOxygen;
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;
    private SceneTransition sceneTransition;
    private bool gameEnded = false;

    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
        currentOxygen = maxOxygen;
    }

    void Update()
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= Time.deltaTime;
            oxygenBar.fillAmount = currentOxygen / maxOxygen;
        }
        else if (!gameEnded)
        {
            gameEnded = true;
            print("Game Over");
            EndGame();
        }
    }


    void EndGame()
    {
        MainManager.Instance.UpdateHighScore(currentScore);
        sceneTransition.FadeToScene("Final Screen");
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