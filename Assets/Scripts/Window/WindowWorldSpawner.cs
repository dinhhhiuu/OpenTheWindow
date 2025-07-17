using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWorldSpawner : MonoBehaviour {
    public WindowItem window;
    private string itemUniqueId;

    private void Awake() {
        itemUniqueId = gameObject.name;
        WindowWorld.SpawnWindowWorld(transform.position, window, itemUniqueId);
        Destroy(gameObject);
    }
}
