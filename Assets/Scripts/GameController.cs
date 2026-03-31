using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public StartPanel startPanel;
    public OverPanel overPanel;
    public ScorecardPanel scorecardPanel;
    public RestartButton restartButton;
    public ExitButton exitButton;

    public Rigidbody2D player;
    public Player character;
    public BaseMovement baseMovement;

    public GameObject pipeSpawner;
    public GameObject newText;

    public TextMeshProUGUI displayScore, bestScore;

    public static bool start,death;

    public static float velocity, gravity, scale, scalePlayer, baseVelocity, pipeVelocity, spawnRate;
    public static int score, topScore;

    public GameObject BronzeMedal, SilverMedal, GoldMedal;

    public string scoreFile;
    public StreamWriter scorefile;

    void Start()
    {
        velocity = 5.5f;
        gravity = 2f;
        baseVelocity = 0.3f;
        scale = 1f;
        scalePlayer = 1f;
        pipeVelocity = -2f;
        spawnRate = 1.85f;

        score = 95;

        start = false;
        death = false;

        BronzeMedal.SetActive(false);
        SilverMedal.SetActive(false);
        GoldMedal.SetActive(false);

        newText.SetActive(false);

        //topScore=int.Parse(File.ReadAllText(scoreFile));
        StreamReader sr = new StreamReader(scoreFile, true);
        topScore = int.Parse(sr.ReadLine());
        sr.Close();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) && !start)
        {
            start = true;
            startPanel.GameStart();
            pipeSpawner.SetActive(true);
            player.gravityScale = gravity*scale;
        }
        if(start)
        {
            UpdateGameData();
        }
    }

    public void Collision()
    {
        death = true;

        overPanel.GameOver();
        scorecardPanel.GameOver();
        restartButton.GameOver();
        exitButton.GameOver();

        Destroy(pipeSpawner);

        player.gravityScale = 0f;
        player.velocity = new Vector2(0f, 0f);
        character.enabled = false;
        baseMovement.enabled = false;
        gravity = 0f;

        displayScore.text = score.ToString();
        UpdateBestScore();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void UpdateBestScore()
    {
        if (score > topScore)
        {
            topScore = score;
            //File.WriteAllText(scoreFile, topScore.ToString());
            //File.Close(scoreFile);

            StreamWriter sw = new StreamWriter(scoreFile, false);
            sw.WriteLine(topScore);
            sw.Close();

            newText.SetActive(true);
        }
        bestScore.text = topScore.ToString();

        if (score >= 10 && score < 20)
        {
            BronzeMedal.SetActive(true);
        }
        else if (score >= 20 && score < 45)
        {
            SilverMedal.SetActive(true);
        }
        else if(score >=45)
        {
            GoldMedal.SetActive(true);
        }
    }

    public void UpdateGameData()
    {
        scale = 3 - 2 * Mathf.Pow(2, -score / 40f);
        scalePlayer = 2 - Mathf.Pow(2, -score / 40f);
        player.gravityScale = gravity * scalePlayer;
    }
}
