using UnityEngine;

public class PersistCanvas : MonoBehaviour {
    public static PersistCanvas Instance { get; private set; }
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}