using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public string[] spawnIDs;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && PlayerSpawnData.Instance.GetLastDoorID() != null) {
            for (int i = 0; i < spawnPoints.Length; i++) {
                if (spawnIDs[i] == PlayerSpawnData.Instance.GetLastDoorID()) {
                    player.transform.position = spawnPoints[i].position;
                    break;
                }
            }
        }
    }
}
