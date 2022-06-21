using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI gameStartText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highscoreText;
    [SerializeField]
    private TextMeshProUGUI playerLivesText;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameOverPanel;



    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "Score : 0000";
        //highscoreText.text = "Highscore : 0000";
    }

    public void AjustScoreText(int playerScore)
    {
        scoreText.text = $"Score : {playerScore}";
    }

    public void AjustHighscorecoreText(int playerScore)
    {
        highscoreText.text = $"Highscore : {playerScore}";
    }

    public void AjustPlayerLivesText(int playerLives)
    {
        playerLivesText.text = playerLives.ToString();
    }

    public void SetGameStartText(bool active)
    {
        gameStartText.gameObject.SetActive(active);
    }

    public void SetPausePainelActive(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void SetGameOverPainelActive(bool active)
    {
        gameOverPanel.SetActive(active);
    }

}
