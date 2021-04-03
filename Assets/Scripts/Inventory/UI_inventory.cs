using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
    }

    public void SetInventory(Inventory inv)
    {
        this.inventory = inv;

        inventory.OnItemListChanged += Inventory_OnItemsListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemsListChanged(object sender, System.EventArgs a)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Item").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
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
            


            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }



}
