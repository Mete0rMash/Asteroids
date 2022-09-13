using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{   
    public static BulletPooler SharedInstance;

    public GameObject objectToPool;
    
    public int amountToPool;
    public bool willGrow = true;

    [SerializeField] Transform canvas;

    public List<GameObject> pooledObjects;


    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool, canvas);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public List<GameObject> GetPool()
    {
        return pooledObjects;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
