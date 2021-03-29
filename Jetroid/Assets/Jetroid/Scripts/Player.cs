using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60, 100);
    public float jetSpeed = 200f;
    public bool standing;
    public float standingThreshhold = 4f;
    public float airSpeedMultiplier = 0.3f;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float absVelX = Mathf.Abs(body2D.velocity.x);
        float absVelY = Mathf.Abs(body2D.velocity.y);

        if (absVelY <= standingThreshhold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        float forceX = 0f;
        float forceY = 0f;

        if (controller.moving.x != 0)
        {
            if(absVelX < maxVelocity.x)
            {
                float newSpeed = speed * controller.moving.x;
                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
                renderer2D.flipX = forceX < 0;
            }
        }

        if (controller.moving.y > 0)
        {
            if (absVelY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
            }
        }

        body2D.AddForce(new Vector2(forceX, forceY));
    }
}
