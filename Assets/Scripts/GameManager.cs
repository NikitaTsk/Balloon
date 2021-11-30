using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int speed = 6;
    public GameObject balloonPrefab;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public Button restartButton;
    public Button exitButton;

    private int spawnTime = 2;
    private float xRange = 4;
    private float ySpawnPos = 1;
    private int score;
    private Balloon ballon;
    private int scoreSpeed = 0;

    private void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnBalloon());
    }

    IEnumerator SpawnBalloon()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            float xSpawnPos = Random.Range(-xRange, xRange);
            Vector3 randomPos = new Vector3(xSpawnPos, ySpawnPos, 0);
            Instantiate(balloonPrefab, randomPos, Quaternion.identity);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (scoreSpeed == 1100)
        {
            score += 25;
            scoreText.text = "Score : " + score;
            EndGame();
        }
        else
            if (isGameActive && scoreSpeed <= 1200)
        {
            if (scoreSpeed == 300)
            {
                speed = 8;
            }
            else
                if (scoreSpeed == 700)
            {
                speed = 12;
            }
            score += scoreToAdd;
            scoreText.text = "Score : " + score;
            scoreSpeed += 25;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void EndGame()
    {
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
