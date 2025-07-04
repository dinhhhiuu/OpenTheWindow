using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public Vector3 moveInput;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private static Item selectedItem;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventory = PlayerManager.Instance.Inventory;
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
    }

    private void Update() {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if (moveInput.x != 0) {
            if (moveInput.x > 0) {
                transform.localScale = new Vector3(1, 1, 0);
                animator.SetBool("isRightLeft", true);
            } else {
                transform.localScale = new Vector3(-1, 1, 0);
                animator.SetBool("isRightLeft", true);
            }
        }
        else {
            animator.SetBool("isRightLeft", false);
        }

        if (moveInput.y != 0) {
            if (moveInput.y > 0) {
                animator.SetBool("isBehind", true);
            } else {
                animator.SetBool("isAhead", true);
            }
        }
        else {
            animator.SetBool("isBehind", false);
            animator.SetBool("isAhead", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            //Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.Collect();
        }
    }

    // Return position
    public Vector3 GetPosition() {
        return transform.position;
    }

    // Use item temporarily
    public void UseItem(Item item) {
        selectedItem = item;
    }

    // Return item temp to check
    public Item GetSelectedItem() {
        return selectedItem;
    }

    // Unselect item
    public void UnSelectItem() {
        selectedItem = null;
    }

    // Return inventory to other script
    public Inventory GetInventory() {
        return inventory;
    }
}
