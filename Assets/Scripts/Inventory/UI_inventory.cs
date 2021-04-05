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

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        mainInventory = itemSlotContainer.Find("MainInventory");
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
        for (int i = 0; i < 5; i++)
        {
            var item = inventory.GetItemArray()[i];
            var itemSlot = mainInventory.Find("ItemSlot" + i);

            Transform itemImageObj = itemSlot.Find("Item");
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
    }
}
