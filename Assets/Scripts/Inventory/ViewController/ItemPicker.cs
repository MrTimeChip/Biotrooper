using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicker : MonoBehaviour
{
    public Transform playerTransform;

    public static ItemPicker instance { get; private set; }

    [SerializeField] private UI_inventory ui_Inventory;
    private Item item;
    private Transform imageObj;

    private void Awake()
    {
        instance = this;
        imageObj = transform.Find("ItemImage");
    }

    public void TakeItem(int slotNum)
    {
        var inv = ui_Inventory.GetInventory();
        item = inv.GetItemArray()[slotNum];
        if (item == null)
        {

        }
        else
        {
            inv.RemoveItem(slotNum);
            imageObj.gameObject.SetActive(true);
            var img = imageObj.GetComponent<Image>();
            img.sprite = item.itemDescriptor.icon;
        }
    }

    public void TakePart(string partName)
    {
        var inv = ui_Inventory.GetInventory();
        item = inv.GetPart(partName);
        if (item == null)
        {

        }
        else
        {
            inv.RemovePart(partName);
            imageObj.gameObject.SetActive(true);
            var img = imageObj.GetComponent<Image>();
            img.sprite = item.itemDescriptor.icon;
        }
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        imageObj.transform.position = mousePos;
    }

    public void DropItem()
    {
        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        var playerX = playerTransform.position.x;

        if (mousePos.x < playerX)
        {
            ItemWorld.SpawnItemWorld(new Vector3(playerX - 0.9f, playerTransform.position.y + 0.3f, playerTransform.position.z), item.itemDescriptor, item.amount);
        }
        else
        { 
            ItemWorld.SpawnItemWorld(new Vector3(playerX + 0.9f, playerTransform.position.y + 0.3f, playerTransform.position.z), item.itemDescriptor, item.amount);
        }

        item = null;
        imageObj.gameObject.SetActive(false);
    }

    public bool HaveItem()
    {
        return item != null;
    }

    public void SetItem(int slotNum)
    {
        var inv = ui_Inventory.GetInventory();
        item = inv.SetItem(item, slotNum);
        if (item == null)
        {
            imageObj.gameObject.SetActive(false);
        }
        else
        {
            var img = imageObj.GetComponent<Image>();
            img.sprite = item.itemDescriptor.icon;
        }
    }

    public void SetPart(string partName)
    {
        var inv = ui_Inventory.GetInventory();
        if (inv.CanSetPart(item, partName))
        {
            item = inv.SetPart(item, partName);
            if (item == null)
            {
                imageObj.gameObject.SetActive(false);
            }
            else
            {
                var img = imageObj.GetComponent<Image>();
                img.sprite = item.itemDescriptor.icon;
            }
        }
    }
}
