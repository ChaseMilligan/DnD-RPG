using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    private int facingDirection = 2;

    Vector2 movement;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0 && movement.y == 0) {
            facingDirection = 1;
        } else if (movement.x < 0 && movement.y == 0) {
            facingDirection = 3;
        }

        if (movement.y > 0 && movement.x == 0) {
            facingDirection = 0;
        } else if (movement.y < 0 && movement.x == 0) {
            facingDirection = 2;
        }

        animator.SetInteger("Facing", facingDirection);
    }

    void FixedUpdate() {
        
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
