using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnClickOutside2D : MonoBehaviour {
    [SerializeField] private GameObject targetToHide;

    private void OnMouseDown() {
        if (targetToHide != null) {
            targetToHide.SetActive(false);
        }
    }
}
