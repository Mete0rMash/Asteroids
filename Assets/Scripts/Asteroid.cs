using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Asteroid : CollisionObject
{
    private HUD hud;

    private void Awake()
    {
        GameObject hudGeneral = GameObject.FindWithTag("HUD");

        hud = hudGeneral.GetComponent<HUD>();
    }

    public override void OnCollision(GameObject obj)
    {
        this.gameObject.SetActive(false);
        //obj.gameObject.SetActive(false);

        hud.IncrementScore();
    }

    private void OnDisable()
    {
        this.CancelInvoke();
    }

    public float verticalInputAcceleration;
    public float horizontalInputAcceleration;

    public float maxSpeed = 300;
    public float maxRotationSpeed = 300;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;

    private void Update()
    {
        verticalInputAcceleration = Random.Range(25f, 200f);
        horizontalInputAcceleration = 18;

        Vector3 acceleration =  verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;


        float zTurnAcceleration = -1  * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);


        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);


        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);


        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }
}
