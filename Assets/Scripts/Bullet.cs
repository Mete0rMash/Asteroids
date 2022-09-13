using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Bullet : MonoBehaviour
{
    private float speed = 200;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("Destroy", 2.5f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

}
