using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPadCharController : MonoBehaviour {
    public enum CharWindow {
        w,
        i,
        n,
        d,
        o,
    }

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Image image;

    private CharWindow currentChar = CharWindow.w;
    public CharWindow correctChar;

    public void ChangeChar() {
        int nextChar = ((int)currentChar + 1) % sprite.Length;
        currentChar = (CharWindow)nextChar;
        image.sprite = sprite[nextChar];
    }

    public bool isCorrectChar() {
        return currentChar == correctChar;
    }

    public void ResetChar() {
        currentChar = CharWindow.w;
        image.sprite = defaultSprite;
    }
}
