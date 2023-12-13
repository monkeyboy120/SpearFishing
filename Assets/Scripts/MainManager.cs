using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int HighScore { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHighScore(int score)
    {
        if (score > HighScore)
        {
            HighScore = score;
            // Save high score to persistent storage if needed
        }
    }
}