using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWorldSpawner : MonoBehaviour {
    public WindowItem window;
    public string itemUniqueId;

    private void Awake() {
        WindowWorld.SpawnWindowWorld(transform.position, window, itemUniqueId);
        Destroy(gameObject);
    }
}
