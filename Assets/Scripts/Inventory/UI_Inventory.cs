using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Inventory : MonoBehaviour {
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private player player;

    private UI_ItemSlot activeSlot = null;

    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetPlayer(player player) {
        this.player = player;
    }

    public void SetInventory(Inventory inventory) {
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
        // Clear old slots except the template
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

            // Add UI_ItemSlot script for click handling
            UI_ItemSlot slotClick = itemSlotRectTransform.gameObject.AddComponent<UI_ItemSlot>();
            slotClick.Setup(item, inventory, player, this);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * (itemSlotCellSize - 10f));

            // Set sprite
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            // Set amount text
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            uiText.SetText(item.amount > 1 ? item.amount.ToString() : "");

            x++;
            if (x > 3) {
                x = 0;
                y--;
            }
        }
    }

    public void SetActiveSlot(UI_ItemSlot slot) {
        // If click on the same active slot, toggle background off
        if (activeSlot == slot) {
            activeSlot.HideBackground();
            activeSlot = null;
            player.Instance.UnSelectItem();
            return;
        }

        // Hide background of previous slot
        if (activeSlot != null) {
            activeSlot.HideBackground();
        }

        // Set new active slot
        activeSlot = slot;

        // Show background of new slot
        if (activeSlot != null) {
            activeSlot.ShowBackground();
        }
    }

    private void OnDestroy() {
        if (inventory != null)
            inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    // ===================== UI Item Slot ======================
    public class UI_ItemSlot : MonoBehaviour, IPointerClickHandler {
        private Item item;
        private Inventory inventory;
        private player player;
        private GameObject backgroundGO;
        private UI_Inventory uiInventory;

        public void Setup(Item item, Inventory inventory, player player, UI_Inventory uiInventory) {
            this.item = item;
            this.inventory = inventory;
            this.player = player;
            this.uiInventory = uiInventory;

            backgroundGO = transform.Find("background").gameObject;
            backgroundGO.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (player == null) player = FindObjectOfType<player>();
            if (inventory == null && player != null) inventory = player.GetInventory();

            if (eventData.button == PointerEventData.InputButton.Left) {
                // Use item
                if (player != null) {
                    player.UseItem(item);
                }
                // Toggle active slot
                if (uiInventory != null) {
                    uiInventory.SetActiveSlot(this);
                }
            }
        }

        public void ShowBackground() {
            if (backgroundGO != null) backgroundGO.SetActive(true);
        }

        public void HideBackground() {
            if (backgroundGO != null) backgroundGO.SetActive(false);
        }
    }
}