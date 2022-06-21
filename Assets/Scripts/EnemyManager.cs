using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 StartPos = new Vector3(4.5f, 0, 0);

    [SerializeField]
    private float spaceX = 0.75f;
    [SerializeField]
    private float spaceY = 0.75f;

    [SerializeField]
    private GameManager gameManager;

    private EnemyMovement enemyMovement;

    [HideInInspector]
    public ScoreManager scoreManager;

    public float fireRate = 2f;

    private float fireTimer = 0;

    [Range(1, 5)]
    private int enemyQuantity = 2;
    public int EnemyQuantity { get => enemyQuantity; }


    public int enemyCount = 0;

    [SerializeField]
    private List<Enemy> enemies1 = new List<Enemy>();
    private List<Enemy> enemies2 = new List<Enemy>();
    private List<Enemy> enemies3 = new List<Enemy>();
    private List<Enemy> enemies4 = new List<Enemy>();
    private List<Enemy> enemies5 = new List<Enemy>();
    private List<Enemy> enemies6 = new List<Enemy>();
    private List<Enemy> enemies7 = new List<Enemy>();
    private List<Enemy> enemies8 = new List<Enemy>();
    private List<Enemy> enemies9 = new List<Enemy>();
    private List<Enemy> enemies10 = new List<Enemy>();
    private List<Enemy> enemies11 = new List<Enemy>();
    private List<Enemy> enemies12 = new List<Enemy>();
    private List<Enemy> enemies13 = new List<Enemy>();
    [SerializeField]
    private List<Enemy>[] enemiesArray;
    public List<Enemy>[] EnemiesArray
    {
        get => enemiesArray;
    }



    // Start is called before the first frame update
    void Start()
    {

        enemiesArray = new List<Enemy>[13];
        enemiesArray[0] = enemies1;
        enemiesArray[1] = enemies2;
        enemiesArray[2] = enemies3;
        enemiesArray[3] = enemies4;
        enemiesArray[4] = enemies5;
        enemiesArray[5] = enemies6;
        enemiesArray[6] = enemies7;
        enemiesArray[7] = enemies8;
        enemiesArray[8] = enemies9;
        enemiesArray[9] = enemies10;
        enemiesArray[10] = enemies11;
        enemiesArray[11] = enemies12;
        enemiesArray[12] = enemies13;

        //SpawnEnemies();


        if (scoreManager == null)
        {
            scoreManager = gameManager.scoreManager;
            //scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }
        enemyMovement = GetComponent<EnemyMovement>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.waveStarted)
            ShootCheck();
    }

    private void ShootCheck()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            int chosenColumn = Random.Range(0, enemiesArray.Length);
            if (enemiesArray[chosenColumn].Count > 0)
            {
                for (int i = 0; i < enemiesArray[chosenColumn].Count; i++)
                {
                    if (enemiesArray[chosenColumn][i].gameObject.activeSelf == true)
                    {
                        enemiesArray[chosenColumn][i].Shoot();
                        fireTimer = 0;
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }
    }

    public void SpawnEnemies()
    {
        //i = coluna, j = linha
        for (int i = 0; i < enemiesArray.Length; i++)
        {
            for (int j = 0; j < enemyQuantity; j++)
            {
                Enemy enemy = EnemyPool.Instance.GetObject();
                enemy.transform.position = StartPos + new Vector3(-spaceX * i, spaceY * j, 0);
                enemy.transform.rotation = transform.rotation;
                //enemy.gameObject.SetActive(true);
                enemy.enemyManager = this;
                enemy.column = i;
                enemiesArray[i].Add(enemy);
                enemyCount++;
            }
        }
        enemyQuantity++;
        //enemyMovement.StartMovement();
        StartCoroutine("Spawn");
    }

    public void EnemyDied(Enemy enemy)
    {
        scoreManager.AddPoints(10);
        enemyCount--;
            SoundManager.PlaySound(SoundManager.Sound.EnemyDeath);
        if (enemyCount <= 0)
        {
            enemyMovement.StopMovement();
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                enemiesArray[i].Clear();
            }
        }
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < enemiesArray.Length; i++)
        {
            for (int j = 0; j < enemiesArray[i].Count; j++)
            {

                enemiesArray[i][j].gameObject.SetActive(true);
            }
            SoundManager.PlaySound(SoundManager.Sound.EnemyMovement);
            yield return new WaitForSeconds(.5f);
        }
        gameManager.waveStarted = true;        
        enemyMovement.StartMovement();
    }
}
