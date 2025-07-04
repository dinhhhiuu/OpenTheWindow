using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour {
    public static ItemSaveManager Instance;
    private HashSet<string> collectedItems = new HashSet<string>(); // Save item player collected

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Add item player collected to list
    public void CollectItem(string itemId) {
        collectedItems.Add(itemId);
    }

    // Return item in collectedlist
    public bool IsItemCollected(string itemId) {
        return collectedItems.Contains(itemId);
    }
}
