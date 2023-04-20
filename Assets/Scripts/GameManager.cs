using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Start is called before the first frame update

    int score = 0;
    bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int lives = 3;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    public GameObject highScorePanel;
    int highScore;
    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore()
    {
        if(!gameOver)
            score++;
        scoreText.text = score.ToString();
        highScore = Mathf.Max(highScore, score);
        //print(score);
    }

    public void decreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);

        }
        if (lives <= 0) {

            gameOver = true;
            GameOver();
        }
        
    }
    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove= false;
        gameOverPanel.SetActive(true);
        highScoreText.text = "HighScore: " + highScore.ToString();
        PlayerPrefs.SetInt("HighScore", highScore);
        highScorePanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}


