using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenecicPoolingTEst : MonoBehaviour
{
    public float fireRate = .5f;

    private float fireTimer = 0;

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate)
        {
            fireTimer = 0;
            FireShoot();
        }
    }

    private void FireShoot()
    {
        var shoot = PlayerShotPool.Instance.GetObject();
        shoot.transform.position = transform.position;
        shoot.transform.rotation = transform.rotation;
        shoot.gameObject.SetActive(true);
    }
}
