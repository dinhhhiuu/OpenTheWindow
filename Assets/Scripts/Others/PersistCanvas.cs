using UnityEngine;

public class PersistCanvas : MonoBehaviour {
    void Awake() {
        // Đảm bảo chỉ tồn tại 1 Canvas duy nhất
        if (FindObjectsOfType<Canvas>().Length > 1) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}