using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUIOnClick : MonoBehaviour {
    [SerializeField] private GameObject uiToshow;

    private void OnMouseDown() {
        if (uiToshow != null) uiToshow.SetActive(true);
    }

    private void Update() {
        if (KeypadController.isCorrect) GetComponent<Collider2D>().enabled = false;
    }
}
