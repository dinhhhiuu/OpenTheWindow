using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAssets : MonoBehaviour {
    public static WindowAssets Instance {get; private set;}

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public Transform pfWindow;

    public Sprite WindowBlueSprite;
    public Sprite WindowWhiteSprite;
}
