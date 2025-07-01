using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    /////
    public static ItemWorld DropItem(Vector3 dropPosition, Item item) {
        // Tạo vector ngẫu nhiên trong vòng tròn đơn vị
        Vector3 randomDir = Random.insideUnitCircle * 5f;

        // Tạo item tại vị trí lệch 1 chút so với gốc
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir, item);

        // Tác động lực cho Rigidbody2D để nảy ra
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir, ForceMode2D.Impulse);

        // Dừng lại item sau khi tạo
        itemWorld.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        return itemWorld;
    }





    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1) {
            textMeshPro.SetText(item.amount.ToString());
        } else {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem() {
        return item;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
