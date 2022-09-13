using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private void Awake()
    {
    }

    void Start()
    {
        
    }

    private void Update()
    {
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        GameObject asteroid = AsteroidPooler.SharedInstance.GetPooledObject();

        if (asteroid != null)
        {
            asteroid.transform.position = new Vector3(Random.Range(-300f, 300f), Random.Range(-300f, 300f), 0);
            asteroid.SetActive(true);
        }
    }
}
