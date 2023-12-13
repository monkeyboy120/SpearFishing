using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;

    private void Start()
    {
        scoreText.text = "Score: " + MainManager.Instance.HighScore;
        highScoreText.text = "High Score: " + MainManager.Instance.HighScore;
    }
}
