using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAssets : MonoBehaviour {
    public static WindowAssets Instance {get; private set;}

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public Transform[] windowPrefabs;
    public Sprite[] windowSprites;

    public Transform GetPrefabByType(WindowItem.WindowType type) {
        int idx = (int)type;
        if (idx >= 0 && idx < windowPrefabs.Length) {
            return windowPrefabs[idx];
        }
        return null;
    }

    public Sprite GetSpriteByType(WindowItem.WindowType type) {
        int idx = (int)type;
        if (idx >= 0 && idx < windowSprites.Length) {
            return windowSprites[idx];
        }
        return null;
    }
}
