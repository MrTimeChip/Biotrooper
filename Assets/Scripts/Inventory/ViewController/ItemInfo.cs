using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    private Transform imageObj;
    public UI_inventory ui_inventory;

    private void Awake()
    {
        imageObj = transform.Find("Background");
    }

    private void Update()
    {       
        var mousePos = Input.mousePosition;
        imageObj.transform.position = new Vector3(mousePos.x + imageObj.GetComponent<RectTransform>().sizeDelta.x/2 + 20, mousePos.y - imageObj.GetComponent<RectTransform>().sizeDelta.y / 2 - 20, mousePos.z);

        var slot = InventoryInputManager.OverSlotBackground();
        var part = InventoryInputManager.OverPartSlotBackground();

        imageObj.gameObject.SetActive(false);

        if (slot != null && Inventory.isInventoryOpened)
        {
            var num = slot.transform.parent.GetComponent<SlotScript>().slotNum;
            var item = ui_inventory.GetInventory().itemList[num];

            if (item != null)
            {
                imageObj.gameObject.SetActive(true);
                imageObj.Find("Name").GetComponent<TextMeshProUGUI>().SetText(item.itemDescriptor.itemName);
            }
        }
        else if (part != null && Inventory.isInventoryOpened)
        {
            var item = ui_inventory.GetInventory().GetPart(part.transform.parent.name);

            if (item != null)
            {
                imageObj.gameObject.SetActive(true);
                imageObj.Find("Name").GetComponent<TextMeshProUGUI>().SetText(item.itemDescriptor.itemName);
            }
        }        
    }
}