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

    float offset = 0.85f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.x = 0;
        movement.y = 0;
    }

    // Update is called once per frame
    void Update() {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer > offset) {
            ChasePlayer();
            animator.SetFloat("Speed", 1);
        } else if (distToPlayer < agroRange && distToPlayer <= offset) {
            animator.SetFloat("Speed", 0);
            Debug.Log(movement.sqrMagnitude);
            movement.x = 0;
            movement.y = 0;
        } else {
            animator.SetFloat("Speed", 0);
            movement.x = 0;
            movement.y = 0;
        }     
    }

    void FixedUpdate() {        
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            movement.x = 1;
        }
        else if (transform.position.x > player.position.x)
        {
            movement.x = -1;
        }

        if (transform.position.y < player.position.y)
        {
            movement.y = 1;
        }
        else if (transform.position.y > player.position.y)
        {
            movement.y = -1;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }
}
