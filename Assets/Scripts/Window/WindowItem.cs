using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WindowItem {
    public enum WindowType {
        KeyBlue,
        KeyWhite,
        KeyRed,
        KeyYellow,
        KeyBlack,
    }

    public WindowType windowType;

    public Sprite GetSprite() {
        return WindowAssets.Instance.GetSpriteByType(windowType);
    }
}
