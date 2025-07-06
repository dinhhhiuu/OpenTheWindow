using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WindowItem {
    public enum WindowType {
        KeyBlue,
        KeyWhite,
    }

    public WindowType windowType;

    public Sprite GetSprite() {
        switch (windowType) {
            default:
            case WindowType.KeyBlue: return WindowAssets.Instance.WindowBlueSprite;
            case WindowType.KeyWhite: return WindowAssets.Instance.WindowWhiteSprite;
        }
    }
}
