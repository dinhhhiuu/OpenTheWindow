using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    public float speed = 5.0f;
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
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemworld = collider.GetComponent<ItemWorld>();
        if (itemworld != null) {
            inventory.AddItem(itemworld.GetItem());
            itemworld.DestroySelf();
        }
    }
}
