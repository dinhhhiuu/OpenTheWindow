using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSlot : MonoBehaviour, IPointerClickHandler
{
    private Item item;
    private Inventory inventory;
    private player player;

    public void Setup(Item item, Inventory inventory) {
        this.item = item;
        this.inventory = inventory;
    }

    public void SetPlayer(player player) {
        this.player = player;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            Debug.Log("Click chuột trái: DROP");
            inventory.RemoveItem(item); // hoặc inventory.DropItem(item);
        }
        else if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log("Click chuột phải: USE");
            ItemWorld.DropItem(player.GetPosition(), item);
        }
    }
}
