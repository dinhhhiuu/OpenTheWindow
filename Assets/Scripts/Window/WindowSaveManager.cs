using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSaveManager : MonoBehaviour {
    public static WindowSaveManager Instance;
    private HashSet<string> collectedWindows = new HashSet<string>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void CollectedWindow(string windowuniqueId) {
        collectedWindows.Add(windowuniqueId);
    }

    public bool IsWindowCollected(string windowuniqueId) {
        return collectedWindows.Contains(windowuniqueId);
    }
}
