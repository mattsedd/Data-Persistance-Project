using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    public static MainManager instance;

    [Header("Player Name Settings")]
    private string playerName;
    public TextMeshProUGUI playerNameText;

    [Header("Score Settings")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Variables to store high score data
    private int highScore;
    private string highScorePlayerName;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Load high score and player name
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScorePlayerName = PlayerPrefs.GetString("HighScorePlayerName", "None");
    }

    void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameText.text = playerName;

        // Update the high score display at the start
        highScoreText.text = $"High Score: {highScorePlayerName} : {highScore}";

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        scoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        // Check if the current score is higher than the high score
        if (m_Points > highScore)
        {
            // Update the high score and player name
            highScore = m_Points;
            highScorePlayerName = playerName;

            // Save the new high score and player name
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighScorePlayerName", highScorePlayerName);
            PlayerPrefs.Save();

            // Update the high score display
            highScoreText.text = $"High Score: {highScorePlayerName} : {highScore}";
        }
    }
}