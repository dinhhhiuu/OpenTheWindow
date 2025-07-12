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
    private string itemID;
    private Collider2D cachedCollider;

    private void Awake() {
        itemID = gameObject.name;
        cachedCollider = GetComponent<Collider2D>();
        if (!itemStateDict.ContainsKey(itemID))
            itemStateDict[itemID] = false;

        string nameKey = key.name;
        if (KeyManager.Instance != null && KeyManager.Instance.HasKey(nameKey)) {
            key.SetActive(true);
        }
    }

    private void Start() {
        if (itemStateDict[itemID])
            cachedCollider.enabled = false;
    }

    private void OnMouseDown() {
        if (!itemStateDict[itemID] && uiToshow != null)
            uiToshow.SetActive(true);
    }

    private void Update() {
        if (!itemStateDict[itemID]) {
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
            if (cachedCollider.enabled)
                cachedCollider.enabled = false;
        }
    }
}