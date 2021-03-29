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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float absValX = Mathf.Abs(body2D.velocity.x);
        float absValY = Mathf.Abs(body2D.velocity.y);

        if (absValY <= standingThreshhold)
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
            if (absValX < maxVelocity.x)
            {
                float newSpeed = speed * controller.moving.x;
                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
                renderer2D.flipX = forceX < 0;
            }

            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0)
        {
            if (absValY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
            }

            animator.SetInteger("AnimState", 2);
        }
        else if (absValY > 0 && !standing)
        {
            animator.SetInteger("AnimState", 3);
        }

        body2D.AddForce(new Vector2(forceX, forceY));
    }
}
