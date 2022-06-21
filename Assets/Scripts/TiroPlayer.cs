using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    public float tiroVel = .1f;
    private Player playerReference;
    public Player PlayerReference {
        get { return playerReference; }
        set
        { if (playerReference == null)
                playerReference = value;
            else
                throw new System.Exception("Algo de errado esta acontecendo ao setar a referencia do player no tiro");
            ;
        }            
    }

    public Rigidbody2D rig;

    private void Start()
    {
        rig.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position = transform.position + new Vector3(0, tiroVel , 0);
        rig.velocity = new Vector3(0, tiroVel, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("EnemyShoot"))
        {
            playerReference.isShooting = false;
            PlayerShotPool.Instance.ReturnObjectToPool(this);
        }
    }

}
