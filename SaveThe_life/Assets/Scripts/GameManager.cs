using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver = false;
    int score = 0;

    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreTextPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);


        scoreTextPanel.text = "Score: " + score;
        GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>().StopSpawing();
    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            Debug.Log(score);

            scoreText.text = score.ToString();
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Reset()
    {
        SceneManager.LoadScene("Game");
    }
}
