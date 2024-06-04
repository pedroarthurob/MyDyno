using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Dyno player;
    private ObstacleSpawner obstacleSpawner;
    private CloudSpawner cloudSpawner;
    private BushSpawner bushSpawner;
    [SerializeField]
    private Image gameOver;
    [SerializeField]
    private Image gamePause;
    private bool onPause = false;
    private ScoreManager scoreManager;

    [SerializeField]
    public TMP_Text score_Text;

    void Start()
    {
        player = FindObjectOfType<Dyno>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        cloudSpawner = FindObjectOfType<CloudSpawner>();
        bushSpawner = FindObjectOfType<BushSpawner>();
        scoreManager= FindObjectOfType<ScoreManager>();

        NewGame();
    }

    private void Update()
    {
        if (onPause && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        } else if (!onPause && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Resume()
    {
        gamePause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        onPause = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        
        gamePause.gameObject.SetActive(true);
        Transform currentScoreTransform = gamePause.transform.Find("Current Score");
        var currentScore = currentScoreTransform.gameObject.GetComponent<TextMeshProUGUI>();
        currentScore.text = scoreManager.score_Text.text;
        onPause = true;
        //gamePause.GetComponent<Ga>().text = scoreManager.score_Text.text;
    }

    public void MainMenu()
    {

    }

    public void NewGame()
    {
        gamePause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Obstacle[] obstacles = FindObjectsOfType<Egg>();
        
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        obstacles = FindObjectsOfType<Fossil>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        scoreManager.UpdateScore(0);

        player.gameObject.SetActive(true);
        obstacleSpawner.gameObject.SetActive(true);
        cloudSpawner.gameObject.SetActive(true);
        bushSpawner.gameObject.SetActive(true);

        gameOver.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.gameObject.SetActive(true);
        Transform finalScoreTransform = gameOver.transform.Find("Final Score");
        var finalScore = finalScoreTransform.gameObject.GetComponent<TextMeshProUGUI>();
        finalScore.text = scoreManager.score_Text.text;
        //gameOver.GetComponent<TMP_Text>().text = scoreManager.score_Text.text;
    }
}
