using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {
    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public Transform pfItemWorld;

    public Sprite KeyBlueSprite;
    public Sprite KeyWhiteSprite;
    public Sprite CoinSprite;

}
