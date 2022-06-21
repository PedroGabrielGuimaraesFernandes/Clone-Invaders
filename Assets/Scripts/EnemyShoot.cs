using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float tiroVel = .1f;

    public Rigidbody2D rig;

    private void Start()
    {
        rig.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        //transform.position = transform.position + new Vector3(0, -tiroVel, 0);
        rig.velocity = new Vector3(0, -tiroVel, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
            EnemyShootPool.Instance.ReturnObjectToPool(this);
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Shoot"))
        {
            EnemyShootPool.Instance.ReturnObjectToPool(this);
        }
    }
}
