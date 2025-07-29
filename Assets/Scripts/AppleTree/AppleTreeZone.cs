using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeZone : MonoBehaviour {
    public static AppleTreeZone Instance { get; private set; }

    private bool isCut = false;
    private Animator animator;
    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject appleTree;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        animator = appleTree.GetComponent<Animator>();
    }

    private void Update() {
        if (isCut) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
            player.UnSelectItem();
        } else if (selectedItem.itemType.ToString() == "Sword") {
            Debug.Log("Đúng vật phẩm");
            isCut = true;
            animator.SetTrigger("isCut");
            apple.SetActive(true);
            player.UnSelectItem();
        } else {
            Debug.Log("Sai vật phẩm");
            player.UnSelectItem();
        }
    }
}
