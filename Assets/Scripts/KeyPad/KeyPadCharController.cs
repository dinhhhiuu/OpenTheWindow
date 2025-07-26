using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPadCharController : MonoBehaviour {
    public enum CharWindow {
        x,
        w,
        i,
        n,
        d,
        o,
    }

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Image image;

    private CharWindow currentChar = CharWindow.x;
    public CharWindow correctChar;

    // Change char
    public void ChangeChar() {
        int nextChar = ((int)currentChar + 1) % sprite.Length;
        currentChar = (CharWindow)nextChar;
        image.sprite = sprite[nextChar];
    }

    // Check char
    public bool isCorrectChar() {
        return currentChar == correctChar;
    }

    // Reset
    public void ResetChar() {
        currentChar = CharWindow.x;
        image.sprite = defaultSprite;
    }
}
