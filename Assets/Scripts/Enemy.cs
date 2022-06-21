using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyManager enemyManager;

    public int column;
    // Start is called before the first frame update
    void Start()
    {
        if(enemyManager == null)
        {
            //enemyManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Die();
        }

    }

    public void Shoot()
    {
        EnemyShoot shoot = EnemyShootPool.Instance.GetObject();
        shoot.transform.position = transform.position;
        shoot.transform.rotation = transform.rotation;
        shoot.gameObject.SetActive(true);
    }

    private void Die()
    {
        Explosao explosion = ExplosionPool.Instance.GetObject();
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
        //enemyManager.scoreManager.AddPoints(10);
        //enemyManager.enemyCount--;
        enemyManager.EnemyDied(this);
        EnemyPool.Instance.ReturnObjectToPool(this);
    }
}
