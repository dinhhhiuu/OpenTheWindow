using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadColorManager : MonoBehaviour {
    public KeyPadColorController[] colorControllers;

    public void CheckAllKeypads() {
        foreach (var kp in colorControllers)
        {
            Debug.Log("Sai màu");
            if (!kp.isCorrectColor()) return;
        }
        Debug.Log("Đúng màu");
        transform.parent.gameObject.SetActive(false);
    }

    public void ResetAllKeypads() {
        foreach (var kp in colorControllers) {
            kp.ResetColor();
        }
        transform.parent.gameObject.SetActive(false);
    }
}
