using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAgroPlayer : MonoBehaviour
{
    public  Transform player;

    public float agroRange;

    public float moveSpeed;

    public Animator animator;

    private int facingDirection = 2;

    Rigidbody2D rb;

    Vector2 movement;

    public float buffer = 0.85f;

    public float offset = .3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer > buffer) {
            ChasePlayer();
            animator.SetFloat("Speed", 1);
        } else if (distToPlayer < agroRange && distToPlayer < buffer) {
            animator.SetFloat("Speed", 0);            
            movement.x = 0;
            movement.y = 0;
        } else {
            animator.SetFloat("Speed", 0);
            movement.x = 0;
            movement.y = 0;
        }   
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetInteger("Facing", facingDirection);          
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x - (buffer - offset))
        {
            movement.x = 1;
            facingDirection = 1;
        }
        else if (transform.position.x > player.position.x + (buffer - offset))
        {
            movement.x = -1;
            facingDirection = 3;
        } else {
            movement.x = 0;
        }

        if (transform.position.y < player.position.y - (buffer - offset))
        {
            movement.y = 1;
            facingDirection = 0;
        }
        else if (transform.position.y > player.position.y + (buffer - offset))
        {
            movement.y = -1;
            facingDirection = 2;
        } else {
            movement.y = 0;
        }        
    }
}
