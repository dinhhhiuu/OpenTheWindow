using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadCharController : MonoBehaviour {
    public enum CharWindow {
        w,
        i,
        n,
        d,
        o,
    }

    [SerializeField] private TextMeshProUGUI text;
    private CharWindow currentChar = CharWindow.w;
    private List<string> charList = new List<string> { "w", "i", "n", "d", "o" };
    public CharWindow correctChar;

    public void ChangeChar() {
        int nextChar = ((int)currentChar + 1) % charList.Count;
        currentChar = (CharWindow)nextChar;
        text.text = charList[nextChar].ToString();
    }

    public bool isCorrectChar() {
        return currentChar == correctChar;
    }

    public void ResetChar() {
        currentChar = CharWindow.w;
        text.text = "";
    }
}
