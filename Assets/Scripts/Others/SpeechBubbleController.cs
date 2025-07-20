using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubbleController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI bubbleText;
    [SerializeField] private GameObject bubbleBG;

    private Coroutine typingCoroutine;

    public void Show(string message, float duration = 0.5f, float typeDelay = 0.05f) {
        if (typingCoroutine != null) {
            StopCoroutine(typingCoroutine);
        }
        bubbleBG.SetActive(true);
        typingCoroutine = StartCoroutine(TypeText(message, duration, typeDelay));
    }

    private IEnumerator TypeText(string message, float duration, float typeDelay) {
        bubbleText.text = "";
        foreach (char c in message) {
            bubbleText.text += c;
            yield return new WaitForSeconds(typeDelay);
        }

        yield return new WaitForSeconds(duration);
        bubbleBG.SetActive(false);
    }
}
