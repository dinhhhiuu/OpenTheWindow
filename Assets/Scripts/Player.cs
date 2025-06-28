using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    public float speed = 1.0f;
    private Rigidbody2D rb;

    private void Awake() {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemworld = collider.GetComponent<ItemWorld>();
        if (itemworld != null) {
            inventory.AddItem(itemworld.GetItem());
            itemworld.DestroySelf();
        }
    }
}
