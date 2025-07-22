using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadCharManager : MonoBehaviour {
    public KeyPadCharController[] charControllers;
    [SerializeField] private GameObject key;
    public static bool isCorrectChar = false;

    public void CheckAllKeypads() {
        foreach (var kp in charControllers) {
            Debug.Log("Sai ki tự");
            if (!kp.isCorrectChar()) return;
        }
        Debug.Log("Đúng ki tự");
        transform.parent.gameObject.SetActive(false);
        key.SetActive(true);
        string nameKey = key.name;
        KeyManager.Instance.SetKey(nameKey);
        isCorrectChar = true;
    }

    public void ResetAllKeypads() {
        foreach (var kp in charControllers) {
            kp.ResetChar();
        }
        transform.parent.gameObject.SetActive(false);
    }

    public static void Reset() {
        isCorrectChar = false;
    }
}
