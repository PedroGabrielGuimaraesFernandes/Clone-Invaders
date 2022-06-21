using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private int playerScore = 0;
    [SerializeField]
    private int playerHighScore = 0;

    private void Awake()
    {
        MainData.LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHighScore = MainData.highestHighscore;
        uIManager.AjustHighscorecoreText(playerHighScore);
        uIManager.AjustScoreText(playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHighScore < playerScore)
        {
            playerHighScore = playerScore;
            MainData.highestHighscore = playerHighScore;
            MainData.SaveHighscore();
            uIManager.AjustHighscorecoreText(playerHighScore);
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        uIManager.AjustScoreText(playerScore);
    }
}
