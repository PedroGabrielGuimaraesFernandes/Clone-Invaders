using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deactivate()
    {
        ExplosionPool.Instance.ReturnObjectToPool(this);
        gameObject.SetActive(false);
    }
}
