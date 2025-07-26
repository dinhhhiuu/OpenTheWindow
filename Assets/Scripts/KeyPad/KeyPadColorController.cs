using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadColorController : MonoBehaviour {
    public enum ColorKeypad {
        white,
        red,
        green,
        blue,
        yellow,
    }

    public Image image;
    public ColorKeypad currentColor = ColorKeypad.white;
    public List<Color> colorList;

    public ColorKeypad correctColor;

    // Change color
    public void ChangeColor() { 
        int nextColor = ((int)currentColor + 1) % colorList.Count;
        currentColor = (ColorKeypad)nextColor;
        image.color = colorList[nextColor];
    }

    // Check color
    public bool isCorrectColor() {
        return currentColor == correctColor;
    }

    // Reset
    public void ResetColor() {
        currentColor = ColorKeypad.white;
        image.color = colorList[0]; 
    }
}
