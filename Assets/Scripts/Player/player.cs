using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour {
    public static player Instance { get; private set; }

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Inventory inventory;
    private static Item selectedItem;

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private string walkableTag = "WalkableZone";
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float wallCheckDistance = 1f;

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

        targetPosition = transform.position;
    }

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

    private void Update() {
        HandleMouseClick();
    }

    private void FixedUpdate() {
        if (isMoving) {
            Vector3 direction = (targetPosition - (Vector3)rb.position).normalized;
            RaycastHit2D wallHit = Physics2D.Raycast(rb.position, direction, wallCheckDistance, wallLayer);

            if (wallHit.collider != null) {
                isMoving = false;
                animator.SetBool("isRightLeft", false);
                animator.SetBool("isAhead", false);
                animator.SetBool("isBehind", false);
                return;
            }

            Vector3 newPos = Vector3.MoveTowards((Vector3)rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            if (Vector3.Distance((Vector3)rb.position, targetPosition) < 0.01f) {
                isMoving = false;
                animator.SetBool("isRightLeft", false);
                animator.SetBool("isAhead", false);
                animator.SetBool("isBehind", false);
            }
        }
    }

    private void HandleMouseClick() {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);

            foreach (RaycastHit2D hit in hits) {
                ItemOnClick item = hit.collider.GetComponent<ItemOnClick>();
                if (item != null) {
                    item.Interact(this);
                    AudioEffectManager.Instance.PlayPickItemSound();
                    return;
                }
                Friend friend = hit.collider.GetComponent<Friend>();
                if (friend != null) {
                    friend.OnMouseDown();
                    return;
                }
                Sister sister = hit.collider.GetComponent<Sister>();
                if (sister != null) {
                    sister.OnMouseDown();
                    return;
                }
            }

            Collider2D hitZone = Physics2D.OverlapPoint(mouseWorldPos);
            if (hitZone != null && hitZone.CompareTag(walkableTag)) {
                targetPosition = mouseWorldPos;
                isMoving = true;

                Vector3 direction = (targetPosition - transform.position).normalized;
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                    transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
                    animator.SetBool("isRightLeft", true);
                    animator.SetBool("isAhead", false);
                    animator.SetBool("isBehind", false);
                } else {
                    animator.SetBool("isRightLeft", false);
                    animator.SetBool("isBehind", direction.y > 0);
                    animator.SetBool("isAhead", direction.y < 0);
                }
            } else {
                Debug.Log("Click ngoài vùng cho phép!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.Collect();
        }
        if (collider.CompareTag("Coin")) {
            AudioEffectManager.Instance.PlayCoinSound();
        } else if (collider.CompareTag("Apple")) {
            AudioEffectManager.Instance.PlayPickItemSound();
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

    // Draw gizmos to show the target position
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 1f);
    }
}