using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {
    public static KeyManager Instance {get; private set;}
    private HashSet<string> keyStates = new HashSet<string>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void SetKey(string key) {
        keyStates.Add(key);
    }

    public bool HasKey(string key) {
        return keyStates.Contains(key);
    }
}
