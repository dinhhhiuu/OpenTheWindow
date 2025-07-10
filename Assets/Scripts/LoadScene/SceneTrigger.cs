using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {
    public Loader.Scene targetScene;
    private string doorID;

    private void Start() {
        doorID = gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            PlayerSpawnData.lastDoorID = doorID;
            Loader.Load(targetScene);
        }
    }
}
