using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    RectTransform player;
    //public GameObject bullet;
    public Transform canvas;
    private float fireTime = .5f;

    private void Awake()
    {
        player = this.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("Fire", fireTime);
        }
    }

    private void Fire()
    {
        GameObject bullet = BulletPooler.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = player.position;
            bullet.transform.rotation = player.rotation;
            bullet.SetActive(true);
        }
    }
}
