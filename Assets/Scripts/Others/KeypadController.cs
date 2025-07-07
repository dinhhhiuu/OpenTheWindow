using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private string correctPassword = "1234";

    private string currentInput = "";
    private int lengthInput = 5;
    private string charAnonymous = "*";

    public static bool isCorrect = false;

    public void OnNumberPressed(string number) {
        if (currentInput.Length < lengthInput) {
            currentInput += number;
            inputText.text += charAnonymous;
        }
    }

    public void OnClear() {
        currentInput = "";
        inputText.text = currentInput;
        transform.parent.gameObject.SetActive(false);
    }

    public void OnSubmit() {
        if (currentInput == correctPassword) {
            Debug.Log("Correct Password");
            transform.parent.gameObject.SetActive(false);
            isCorrect = true;
        } else {
            currentInput = "";
            inputText.text = currentInput;
            Debug.Log("Wrong Password");
        }
    }
}
