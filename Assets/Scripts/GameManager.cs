using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject healthPowerupPrefab;
    public bool isGameActive;
    public int powerupDropMultiplier;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI difficultyText;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    // [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;

    private int score = 0;
    private int health = 5;
    private float spawnRange = 60.0f;
    private float spawnTime = 2f;

    private void Awake() {
        StartGame(DataManager.Instance.Difficulty);
    }

    public void StartGame(int difficulty)
    {
        powerupDropMultiplier = difficulty;
        isGameActive = true;
        InvokeRepeating("SpawnEnemy", 0, spawnTime/difficulty);
        scoreText.gameObject.SetActive(true);
        UpdateScore(0);
        healthText.gameObject.SetActive(true);
        UpdateHealth(0);
        SetDifficultyText(difficulty);
    }

    void SpawnEnemy()
    {
        if (isGameActive){
            int randIdx = Random.Range(0, enemyPrefabs.Length);

            Vector3 randomPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.5f, Random.Range(-spawnRange, spawnRange));
            Instantiate(enemyPrefabs[randIdx], randomPos, enemyPrefabs[randIdx].gameObject.transform.rotation);
        }
        
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;

        scoreText.SetText("Score: " + score);
    }

    public void UpdateHealth(int healthToAdd)
    {
        health += healthToAdd;

        healthText.SetText("Health: " + health);
        if (health == 0)
        {
            GameOver();
        }
    }

    private void SetDifficultyText(int difficulty)
    {
        if (difficulty == 1)
        {
           difficultyText.SetText("Easy");
        }
        if (difficulty == 2)
        {
            difficultyText.SetText("Medium");
        }
        if (difficulty == 3)
        {
            difficultyText.SetText("Hard");
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        DataManager.Instance.SetHighScore(score);
        DataManager.Instance.SaveHighScores();
        gameOverScoreText.SetText(score.ToString());
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SpawnHealthPowerup(Vector3 position, Quaternion rotation)
    {
        Instantiate(healthPowerupPrefab, position, rotation);
    }
}
