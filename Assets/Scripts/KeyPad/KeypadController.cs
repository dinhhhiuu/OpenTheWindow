using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private string correctPassword = "1234";
    [SerializeField] private GameObject key;

    private string currentInput = "";
    private const int lengthInput = 5;
    private const string charAnonymous = "*";
    private string nameKey;

    public static bool isCorrect = false;

    private void Awake() {
        nameKey = key.name;
    }

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

            key.SetActive(true); 
            if (KeyManager.Instance != null) {
                KeyManager.Instance.SetKey(nameKey); 
            }
        } else {
            currentInput = "";
            inputText.text = currentInput;
            Debug.Log("Wrong Password");
        }
    }

    public static void Reset() {
        isCorrect = false;
    }
}
