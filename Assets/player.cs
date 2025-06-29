using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector3 moveInput;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if (moveInput.x != 0) {
            if (moveInput.x > 0) {
                transform.localScale = new Vector3(1, 1, 0);
                animator.SetBool("isRightLeft", true);
            } else {
                transform.localScale = new Vector3(-1, 1, 0);
                animator.SetBool("isRightLeft", true);
            }
        }
        else {
            animator.SetBool("isRightLeft", false);
        }

        if (moveInput.y != 0) {
            if (moveInput.y > 0) {
                animator.SetBool("isBehind", true);
            } else {
                animator.SetBool("isAhead", true);
            }
        }
        else {
            animator.SetBool("isBehind", false);
            animator.SetBool("isAhead", false);
        }
    }
}
