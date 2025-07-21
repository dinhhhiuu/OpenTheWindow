using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    private Animator animator;
    private static bool isCut = false;
    [SerializeField] private GameObject apple;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (isCut) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
            player.UnSelectItem();
        } else if (selectedItem.itemType.ToString() != "Sword") {
            Debug.Log("Sai vật phẩm");
            player.UnSelectItem();
        } else if (selectedItem.itemType.ToString() == "Sword") {
            Debug.Log("Đúng vật phẩm");
            animator.SetTrigger("isCut");
            isCut = true;
            apple.SetActive(true);
        }
    }
}
