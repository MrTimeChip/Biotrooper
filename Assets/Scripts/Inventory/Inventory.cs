using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    public static bool isInventoryOpened = false;

    private Item[] itemList;

    public Inventory()
    {
        itemList = new Item[5];
    }

    public void AddItem(Item item)
    {
        if (item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem != null && inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                    break;
                }
            }
            if (!itemAlreadyInInventory)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (itemList[i] == null)
                    {
                        itemList[i] = item;
                        break;
                    }
                }
            }
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                if (itemList[i] == null)
                {
                    itemList[i] = item;
                    break;
                }
            }
        }    
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(int slotNum)
    {
        itemList[slotNum] = null;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public Item[] GetItemArray()
    {
        return itemList;
    }

    public Item SetItem(Item item, int slotNum)
    {
        var slotItem = itemList[slotNum];
        itemList[slotNum] = item;

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return slotItem;
    }
}
