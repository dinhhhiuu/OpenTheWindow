using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFall : MonoBehaviour {
    public float fallSpeed = 5f;
    public float targetY = 0f;
    private bool landed = false;

    private void Update() {
        if (!landed) {
            Vector3 pos = transform.position;
            pos.y = Mathf.MoveTowards(pos.y, targetY, fallSpeed * Time.deltaTime);
            transform.position = pos;

            if (Mathf.Abs(pos.y - targetY) < 0.1f) {
                landed = true;
            }
        }
    }
}
