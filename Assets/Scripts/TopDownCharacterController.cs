using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        public Animator animator;

        private void Update() {

            Vector2 dir = Vector2.zero;

            if (Input.GetKey(KeyCode.A)) {
                dir.x = -1;
                animator.SetBool("Moving", true);
                animator.SetFloat("Direction", 3);
            } else {
                animator.SetBool("Moving", false);
            }

            if (Input.GetKey(KeyCode.D)) {
                dir.x = 1;
                animator.SetBool("Moving", true);
                animator.SetFloat("Direction", 1);
            } else {
                animator.SetBool("Moving", false);
            }

            if (Input.GetKey(KeyCode.W)) {
                dir.y = 1;
                animator.SetBool("Moving", true);
                animator.SetFloat("Direction", 0);
            } else {
                animator.SetBool("Moving", false);
            }

            if (Input.GetKey(KeyCode.S)) {
                dir.y = -1;
                animator.SetBool("Moving", true);
                animator.SetFloat("Direction", 2);
            } else {
                animator.SetBool("Moving", false);
            }

            dir.Normalize();

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
