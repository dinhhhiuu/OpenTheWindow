using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadColorManager : MonoBehaviour {
    public KeyPadColorController[] colorControllers;
    [SerializeField] private GameObject key;
    public static bool isCorrect = false;

    public void CheckAllKeypads() {
        foreach (var kp in colorControllers)
        {
            Debug.Log("Sai màu");
            if (!kp.isCorrectColor()) return;
        }
        Debug.Log("Đúng màu");
        transform.parent.gameObject.SetActive(false);
        key.SetActive(true);
        string nameKey = key.name;
        KeyManager.Instance.SetKey(nameKey);
        isCorrect = true;
    }

    public void ResetAllKeypads() {
        foreach (var kp in colorControllers) {
            kp.ResetColor();
        }
        transform.parent.gameObject.SetActive(false);
    }

    public static void Reset() {
        isCorrect = false;
    }
}
