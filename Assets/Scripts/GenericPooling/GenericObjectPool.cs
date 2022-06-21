using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T objectPrefab;

    private Queue<T> objectPool = new Queue<T>();

    public static GenericObjectPool<T> Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    public T GetObject()
    {
        if(objectPool.Count <= 0)
        {
            CreateObject(1);
        }
        return objectPool.Dequeue();
    }

    public void ReturnObjectToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);
    }

    public void ReturnObjectToPoolDelayed(T objectToReturn)
    {
        StartCoroutine("ReturnToPool", objectToReturn);
    }

    private IEnumerator ReturnToPool(T objectToReturn)
    {
        //Debug.Log("Coroutine Started");
        //Debug.Log("Coroutine vai esperar 1 segundos");
        yield return new WaitForSeconds(1);
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);

    }

    private void CreateObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            newObject.gameObject.SetActive(false);
            objectPool.Enqueue(newObject);
        };
    }
}
