using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private UIManager uIManager;

    public bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (uIManager == null)        
            uIManager = gameManager.uIManager;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameManager.waveStarted)
        {
            if (!gamePaused)
            {
                Time.timeScale = 0;
                uIManager.SetPausePainelActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gamePaused = true;
            }
            else if(gamePaused)
            {
                Time.timeScale = 1;
                uIManager.SetPausePainelActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gamePaused = false;
            }
        }
    }
}
