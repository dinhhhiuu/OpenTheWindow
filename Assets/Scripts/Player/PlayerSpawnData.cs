using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnData : MonoBehaviour { 
    public static PlayerSpawnData Instance { get; private set; }
    public static string lastDoorID;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public string GetLastDoorID() {
        return lastDoorID;
    }
}
