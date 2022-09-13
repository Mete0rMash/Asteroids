using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CollisionObject
{
    private HUD hud;
    [SerializeField] private RectTransform ship;

    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;

    public float screenTop;
    public float screenBot;
    public float screenR;
    public float screenL;

    private void Awake()
    {
        GameObject hudGeneral = GameObject.FindWithTag("HUD");

        hud = hudGeneral.GetComponent<HUD>();
    }

    public override void OnCollision(GameObject obj)
    {
        hud.DecrementLives();
    }

    private void Update()
    {
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;

        
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;

        Screen();
    }

    private void FixedUpdate()
    {
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

       
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += velocity * Time.deltaTime;
        }
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }

    void Screen()
    {
        Vector2 newPos = ship.position;

        if (ship.position.y > screenTop)
        {
            newPos.y = screenBot;
        }

        if (ship.position.y < screenBot)
        {
            newPos.y = screenTop;
        }

        if (ship.position.x > screenR)
        {
            newPos.x = screenL;
        }

        if (ship.position.x < screenL)
        {
            newPos.x = screenR;
        }

        ship.position = newPos;
    }
}
