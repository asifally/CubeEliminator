using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public bool isGameActive;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;
    private int score = 0;
    private int health = 5;
    private float spawnRange = 60.0f;
    private float spawnTime = 2f;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        InvokeRepeating("SpawnEnemy", 0, spawnTime);
        scoreText.gameObject.SetActive(true);
        UpdateScore(0);
        healthText.gameObject.SetActive(true);
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {

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

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
