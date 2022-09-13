using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOutside : CollisionObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollision(GameObject obj)
    {
        if (obj.gameObject.CompareTag("Limit"))
        {
            if (gameObject.CompareTag("Bullet"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
