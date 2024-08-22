using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int currentScore = 0;
    private int highScore = 0;
    private string playerName;

    private void Start()
    {
        // Load player name and high score
        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        playerNameText.text = "Name: " + playerName;
        highScoreText.text = "High Score: " + highScore;

        // Update score for demonstration (Replace this with your game logic)
        UpdateScore(100); // Example score update
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        scoreText.text = "Score: " + currentScore;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighScorePlayerName", playerName);
            PlayerPrefs.Save();

            highScoreText.text = "High Score: " + highScore + " (by " + playerName + ")";
        }
    }
}
