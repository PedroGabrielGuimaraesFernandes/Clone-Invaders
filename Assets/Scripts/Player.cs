using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private PlayerAnimation playerAnim;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private UIManager uIManager;

    private Vector3 originPos;

    public int playerLives = 3; 

    public float playerVel = .1f;

    public bool isShooting;

    public bool canMove = true;

    //[SerializeField]
    //private int shootLimit = 1;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (uIManager == null)
            uIManager = gameManager.uIManager;
        playerAnim = GetComponent<PlayerAnimation>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        originPos = transform.position;
        uIManager.AjustPlayerLivesText(playerLives);
    }
    
    void LateUpdate()
    {
        if (gameManager.waveStarted)
        {
            if (canMove)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    Vector3 newPosition = transform.position + new Vector3(-playerVel, 0, 0);
                    playerRigidbody.MovePosition(newPosition);
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    Vector3 newPosition = transform.position + new Vector3(playerVel, 0, 0);
                    playerRigidbody.MovePosition(newPosition);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        isShooting = true;
        TiroPlayer tiro = PlayerShotPool.Instance.GetObject();
        tiro.transform.position = transform.position;
        tiro.gameObject.SetActive(true);
        if(tiro.PlayerReference != this)
        tiro.PlayerReference = this;
        SoundManager.PlaySound(SoundManager.Sound.PlayerShoot);
    }

    public void Die()
    {
        playerLives--;
        canMove = false;
        uIManager.AjustPlayerLivesText(playerLives);
        if (playerLives <= 0)
        {
            Explosao explosion = ExplosionPool.Instance.GetObject();
            explosion.transform.position = transform.position;
            explosion.gameObject.SetActive(true);
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
        else
        {
            playerAnim.anim.SetTrigger(playerAnim.damageIndex);
            ResetPlayerPosition();
        }
    }

    public void PlayerRelease()
    {
        canMove = true;
    }


    public void ResetPlayerPosition()
    {
        transform.position = originPos;
    }
}
