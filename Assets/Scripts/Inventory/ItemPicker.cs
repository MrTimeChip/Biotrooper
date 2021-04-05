using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicker : MonoBehaviour
{
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
        inv.RemoveItem(slotNum);

        imageObj.gameObject.SetActive(true);
        var img = imageObj.GetComponent<Image>();
        img.sprite = item.GetSprite();
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        imageObj.transform.position = mousePos;    
    }

    public bool HaveItem()
    {
        return item != null;
    }

    public void SetItem(int slotNum)
    {
        var inv = ui_Inventory.GetInventory();
        inv.SetItem(item, slotNum);
        item = null;
        imageObj.gameObject.SetActive(false);
    }
}
