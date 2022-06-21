using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public UIManager uIManager;
    
    public ScoreManager scoreManager;
    
    public PauseManager pauseManager;
    
    public EnemyManager enemyManager;

    public int wave = 0;

    public bool waveStarted = false;
    public bool waveCanBeStarted = true;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) && !waveStarted && waveCanBeStarted) ||( Input.GetKeyDown(KeyCode.Return) && !waveStarted && waveCanBeStarted))
        {
            waveCanBeStarted = false;
            StartWave();
        }

        if(enemyManager.enemyCount <= 0 && waveStarted)
        {
            EndWave();
        }
        //temp
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && gameOver|| Input.GetKeyDown(KeyCode.Return) && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void StartWave()
    {
        wave++;
        uIManager.SetGameStartText(false);
        //waveStarted = true;
        enemyManager.SpawnEnemies();
    }

    public void EndWave()
    {
        waveCanBeStarted = true;
        waveStarted = false;        
        Player.instance.ResetPlayerPosition();
        uIManager.SetGameStartText(true);
    }

    public void GameOver()
    {
        waveCanBeStarted = true;
        uIManager.SetGameOverPainelActive(true);        
        waveStarted = false;
        gameOver = true;
    }

}
