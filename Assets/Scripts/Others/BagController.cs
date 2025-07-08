using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour {
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;

    public void Toggle() {
        if (target1 != null && target2 != null) {
            target1.SetActive(!target1.activeSelf);
            target2.SetActive(!target2.activeSelf);
        }
    }
}
