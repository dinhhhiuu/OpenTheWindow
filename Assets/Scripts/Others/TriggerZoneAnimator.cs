using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAnimator : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        if (animator == null) {
            animator = GetComponentInParent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            animator.SetBool("isOpen", false);
        }
    }
}
