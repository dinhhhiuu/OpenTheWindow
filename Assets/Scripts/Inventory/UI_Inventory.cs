using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private player player;

    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetPlayer(player player) {
        this.player = player;
    }

    public void SetInventory(Inventory inventory) {
        // Nếu đã đăng ký event trước đó thì bỏ
        if (this.inventory != null)
            this.inventory.OnItemListChanged -= Inventory_OnItemListChanged;

        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) { 
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 60f;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            // Gắn script click trực tiếp trong class gộp
            UI_ItemSlot slotClick = itemSlotRectTransform.gameObject.AddComponent<UI_ItemSlot>();
            slotClick.Setup(item, inventory, player);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * (itemSlotCellSize - 10f));
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            uiText.SetText(item.amount > 1 ? item.amount.ToString() : "");

            x++;
            if (x > 3) {
                x = 0;
                y--;
            }
        }
    }

    private void OnDestroy() {
        // Gỡ đăng ký event khi UI bị xóa
        if (inventory != null)
            inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    // ===================== LỚP LỒNG ======================
    private class UI_ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        private Item item;
        private Inventory inventory;
        private player player;

        public void Setup(Item item, Inventory inventory, player player) {
            this.item = item;
            this.inventory = inventory;
            this.player = player;
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (player == null) player = FindObjectOfType<player>();
            if (inventory == null && player != null) inventory = player.GetInventory();

            if (eventData.button == PointerEventData.InputButton.Left) {
                // Use Item
                player.UseItem(item);
            }
        }
    }
}
