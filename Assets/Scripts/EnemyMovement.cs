using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyManager enemyManager;

    public float leftLimit;
    public float rightLimit;
    public float dowmLimit;
    public float movementDistance = 0.5f;

    public float movementTime = 0.1f;

    public bool left = false;
    public bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
    }

    public void StartMovement()
    {
        StartCoroutine("MoveEnemy");

    }

    public void StopMovement()
    {
        StopCoroutine("MoveEnemy");
    }

    private IEnumerator MoveEnemy()
    {
        //Debug.Log("Coroutine Started");
        //Debug.Log("Coroutine vai esperar 1 segundos");
        yield return new WaitForSeconds(1);

        int line = 0;
        for (int i = 0; i < enemyManager.EnemyQuantity - 1; i++)
        {
            if (right)
            {
                for (int j = 0; j < enemyManager.EnemiesArray.Length; j++)
                {
                    if (enemyManager.EnemiesArray[j][line].gameObject.activeSelf == true) {
                        enemyManager.EnemiesArray[j][line].transform.position += new Vector3(movementDistance, 0, 0);
                        //Debug.Log("Coroutine vai esperar 1 segundos");
                        SoundManager.PlaySound(SoundManager.Sound.EnemyMovement);
                        yield return new WaitForSeconds(movementTime);
                    }
                }
            }
            else if (left)
            {
                for (int j = enemyManager.EnemiesArray.Length - 1; j >= 0; j--)
                {
                    if (enemyManager.EnemiesArray[j][line].gameObject.activeSelf == true)
                    {
                        enemyManager.EnemiesArray[j][line].transform.position += new Vector3(-movementDistance, 0, 0);
                        // Debug.Log("Coroutine vai esperar 1 segundos");
                        SoundManager.PlaySound(SoundManager.Sound.EnemyMovement);
                        yield return new WaitForSeconds(movementTime);
                    }
                }
            }
            line++;
        }
        CheckEnemiesPosition();
        StartMovement();
    }

    public void CheckEnemiesPosition()
    {
        for (int i = 0; i < enemyManager.EnemiesArray.Length; i++)
        {
            for (int j = 0; j < enemyManager.EnemiesArray[i].Count; j++)
            {
                if (right == true)
                {
                    if (enemyManager.EnemiesArray[i][j].transform.position.x >= rightLimit && enemyManager.EnemiesArray[i][j].gameObject.activeSelf)
                    {
                        MoveDown();
                        right = false;
                        left = true;
                        return;
                    }
                }
                if (left == true)
                {
                    if (enemyManager.EnemiesArray[i][j].transform.position.x <= leftLimit && enemyManager.EnemiesArray[i][j].gameObject.activeSelf)
                    {
                        MoveDown();
                        right = true;
                        left = false;
                        return;
                    }
                }
            }
        }
    }

    private void MoveDown()
    {
        for (int i = 0; i < enemyManager.EnemiesArray.Length; i++)
        {
            for (int j = 0; j < enemyManager.EnemiesArray[i].Count; j++)
            {
                if (enemyManager.EnemiesArray[i][j].transform.position.y -0.75f  > dowmLimit)
                {
                    enemyManager.EnemiesArray[i][j].transform.position += new Vector3(0, -.75f, 0);
                }
                else
                {
                    return;
                }
                
            }
        }
    }

    /*private void MoveEnemy(Enemy enemy)
    {

    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(leftLimit, -5, 0), new Vector3(leftLimit, 5, 0));
        Gizmos.DrawLine(new Vector3(rightLimit, -5, 0), new Vector3(rightLimit, 5, 0));
        Gizmos.DrawLine(new Vector3(leftLimit, dowmLimit, 0), new Vector3(rightLimit, dowmLimit, 0));
    }
}
