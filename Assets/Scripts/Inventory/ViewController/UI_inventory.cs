using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform mainInventory;
    private Transform partInventory;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        mainInventory = itemSlotContainer.Find("MainInventory");
        partInventory = itemSlotContainer.Find("PartInventory");
    }

    public void SetInventory(Inventory inv)
    {
        this.inventory = inv;

        inventory.OnItemListChanged += Inventory_OnItemsListChanged;
        RefreshInventoryItems();
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    private void Inventory_OnItemsListChanged(object sender, System.EventArgs a)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        Transform itemImageObj;
        for (int i = 0; i < 5; i++)
        {
            var item = inventory.GetItemArray()[i];
            var itemSlot = mainInventory.Find("ItemSlot" + i);

            itemImageObj = itemSlot.Find("Item");
            Transform uiTextObj = itemSlot.Find("text");

            if (item == null)
            {
                itemImageObj.gameObject.SetActive(false);
                uiTextObj.gameObject.SetActive(false);
            }
            else
            {
                itemImageObj.gameObject.SetActive(true);
                uiTextObj.gameObject.SetActive(true);

                Image image = itemImageObj.GetComponent<Image>();
                image.sprite = item.GetSprite();
                TextMeshProUGUI uiText = uiTextObj.GetComponent<TextMeshProUGUI>();
                if (item.amount > 1)
                {
                    if (item.amount < 10)
                    {
                        uiText.SetText(' ' + item.amount.ToString());
                    }
                    else
                    {
                        uiText.SetText(item.amount.ToString());
                    }
                }
                else
                {
                    uiText.SetText("");
                }
            }                
        }

        UpdatePartView(inventory.armLeft, "LeftArm");
        UpdatePartView(inventory.armRight, "RightArm");
        UpdatePartView(inventory.legLeft, "LeftLeg");
        UpdatePartView(inventory.legRight, "RightLeg");
        UpdatePartView(inventory.body, "Body");
        UpdatePartView(inventory.heart, "Heart");
        UpdatePartView(inventory.eyes, "Eyes");
        UpdatePartView(inventory.lungs, "Lungs");
        UpdatePartView(inventory.stomach, "Stomach");
    }

    private void UpdatePartView(Item partItem, string itemName)
    {
        var partSlot = partInventory.Find(itemName);
        var itemImageObj = partSlot.Find("Item");
        var itemBackImageObj = partSlot.Find("BackgroundItem");
        if (partItem == null)
        {
            itemImageObj.gameObject.SetActive(false);
            itemBackImageObj.gameObject.SetActive(true);

        }
        else
        {
            itemImageObj.gameObject.SetActive(true);
            Image image = itemImageObj.GetComponent<Image>();
            image.sprite = partItem.GetSprite();
            itemBackImageObj.gameObject.SetActive(false);
        }
    }
}
