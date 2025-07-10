using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Start() {
        // Lấy lại player nếu chưa gán
        if (target == null) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }
    }

    void LateUpdate() {
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = -10f; 
        transform.position = smoothedPosition;
    }
}