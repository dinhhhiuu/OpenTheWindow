using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public static player Instance { get; private set; }

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private static Item selectedItem;

    private IEnumerator WaitForUIInventory() {
        while (uiInventory == null) {
            uiInventory = FindObjectOfType<UI_Inventory>();
            if (uiInventory != null) {
                uiInventory.SetInventory(inventory);
                uiInventory.SetPlayer(this);
                break;
            }
            yield return null;
        }
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventory = PlayerManager.Instance.Inventory;
        StartCoroutine(WaitForUIInventory());
    }

    private void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        if (moveInput.x != 0) {
            transform.localScale = new Vector3(moveInput.x > 0 ? 1 : -1, 1, 0);
            animator.SetBool("isRightLeft", true);
        } else {
            animator.SetBool("isRightLeft", false);
        }

        if (moveInput.y != 0) {
            animator.SetBool("isBehind", moveInput.y > 0);
            animator.SetBool("isAhead", moveInput.y < 0);
        } else {
            animator.SetBool("isBehind", false);
            animator.SetBool("isAhead", false);
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.Collect();
        }
        if (collider.CompareTag("Coin")) {
            AudioManager.Instance.PlayCoinSound();
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public void UseItem(Item item) {
        selectedItem = item;
    }

    public Item GetSelectedItem() {
        return selectedItem;
    }

    public void UnSelectItem() {
        selectedItem = null;
    }

    public Inventory GetInventory() {
        return inventory;
    }
}
