using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnData : MonoBehaviour { 
    public static string lastDoorID;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
