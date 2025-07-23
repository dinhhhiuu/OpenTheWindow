using System.Collections.Generic;
using UnityEngine;

public class TriggerUIOnClick : MonoBehaviour
{
    public enum UnlockCondition {
        Keypad,
        KeypadColor,
        KeypadChar,
    }

    [SerializeField] private UnlockCondition unlockCondition;
    [SerializeField] private GameObject uiToshow;
    [SerializeField] private GameObject key;

    private static Dictionary<string, bool> itemStateDict = new Dictionary<string, bool>();
    private static List<TriggerUIOnClick> allInstances = new List<TriggerUIOnClick>();
    private string itemID;
    private Collider2D cachedCollider;

    private void Awake() {
        itemID = gameObject.name;
        cachedCollider = GetComponent<Collider2D>();
        if (!itemStateDict.ContainsKey(itemID))
            itemStateDict[itemID] = false;

        if (key != null) {
            string nameKey = key.name;
            if (KeyManager.Instance != null && KeyManager.Instance.HasKey(nameKey)) {
                key.SetActive(true);
            }
        }
        allInstances.Add(this);
    }
    private void OnDestroy() {
        allInstances.Remove(this);
    }

    private void Start() {
        if (!itemStateDict.ContainsKey(itemID))
            itemStateDict[itemID] = false;

        if (itemStateDict[itemID])
            cachedCollider.enabled = false;
    }

    private void OnMouseDown() {
        if (!itemStateDict.ContainsKey(itemID))
            itemStateDict[itemID] = false;

        if (!itemStateDict[itemID] && uiToshow != null)
            uiToshow.SetActive(true);
    }

    private void Update() {
        // Luôn đảm bảo key tồn tại trước khi truy cập
        if (!itemStateDict.ContainsKey(itemID))
            itemStateDict[itemID] = false;

        if (!itemStateDict[itemID]) {
            cachedCollider.enabled = true;
            switch (unlockCondition) {
                case UnlockCondition.Keypad:
                    if (KeypadController.isCorrect)
                        itemStateDict[itemID] = true;
                    break;
                case UnlockCondition.KeypadColor:
                    if (KeyPadColorManager.isCorrect)
                        itemStateDict[itemID] = true;
                    break;
                case UnlockCondition.KeypadChar:
                    if (KeyPadCharManager.isCorrectChar)
                        itemStateDict[itemID] = true;
                    break;
            }
        }

        if (itemStateDict[itemID])
        {
            if (cachedCollider.enabled) {
            cachedCollider.enabled = false;
        }
        }
    }

    // Hàm reset cho từng instance
    public void ResetInstanceState() {
        itemStateDict[itemID] = false;
        if (cachedCollider != null) {
            cachedCollider.enabled = true;
        }
        if (uiToshow != null)
            uiToshow.SetActive(false);
    }

    // Gọi hàm này khi reset game
    public static void ResetItemStateDict() {
        itemStateDict = new Dictionary<string, bool>();
        foreach (var instance in allInstances) {
            instance.ResetInstanceState();
        }
    }
}