using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    public event EventHandler OnPartUpdated;

    public static bool isInventoryOpened = false;

    public Item[] itemList;
    public Item armLeft;
    public Item armRight;
    public Item legLeft;
    public Item legRight;
    public Item eyes;
    public Item heart;
    public Item body;
    public Item lungs;
    public Item stomach;

    public Inventory()
    {
        itemList = new Item[5];
    }

    public bool AddItem(Item item)
    {
        bool itemIsAdded = false;

        if (item.itemDescriptor.isStackable)
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem != null && inventoryItem.itemDescriptor.itemType == item.itemDescriptor.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                    itemIsAdded = true;
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
                        itemIsAdded = true;
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
                    itemIsAdded = true;
                    break;
                }
            }
        }    
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return itemIsAdded;
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

        if (slotItem != null && slotItem.itemDescriptor.itemType == item.itemDescriptor.itemType && item.itemDescriptor.isStackable)
        {
            slotItem.amount += item.amount;
            slotItem = null;
        }
        else
        {
            itemList[slotNum] = item;
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        return slotItem;
    }

    public Item GetPart(string partName)
    {
        switch(partName)
        {
            case "LeftArm": return armLeft;
            case "RightArm": return armRight;
            case "Eyes": return eyes;
            case "Body": return body;
            case "RightLeg": return legRight;
            case "LeftLeg": return legLeft;
            case "Heart": return heart;
            case "Lungs": return lungs;
            case "Stomach": return stomach;
            default: return null;
        }
    }

    public void RemovePart(string partName)
    {
        switch (partName)
        {
            case "LeftArm": armLeft = null; break;
            case "RightArm": armRight = null; break;
            case "Eyes": eyes = null; break;
            case "Body": body = null; break;
            case "RightLeg": legRight = null; break;
            case "LeftLeg": legLeft = null; break;
            case "Heart": heart = null; break;
            case "Lungs": lungs = null; break;
            case "Stomach": stomach = null; break;
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        OnPartUpdated?.Invoke(this, EventArgs.Empty);
    }

    public bool CanSetPart(Item item, string partName)
    {
        switch (partName)
        {
            case "LeftArm": return item.itemDescriptor.itemType == ItemType.Arm;
            case "RightArm": return item.itemDescriptor.itemType == ItemType.Arm;
            case "Eyes": return item.itemDescriptor.itemType == ItemType.Eyes;
            case "Body": return item.itemDescriptor.itemType == ItemType.Body;
            case "RightLeg": return item.itemDescriptor.itemType == ItemType.Leg;
            case "LeftLeg": return item.itemDescriptor.itemType == ItemType.Leg;
            case "Heart": return item.itemDescriptor.itemType == ItemType.Heart;
            case "Lungs": return item.itemDescriptor.itemType == ItemType.Lungs;
            case "Stomach": return item.itemDescriptor.itemType == ItemType.Stomach;
        }
        return false;
    }

    public Item SetPart(Item item, string partName)
    {
        Item tmpItem = null;
        switch (partName)
        {
            case "LeftArm": tmpItem = armLeft; armLeft = item; break;
            case "RightArm": tmpItem = armRight; armRight = item; break;
            case "Eyes": tmpItem = eyes; eyes = item; break;
            case "Body": tmpItem = body; body = item; break;
            case "RightLeg": tmpItem = legRight; legRight = item; break;
            case "LeftLeg": tmpItem = legLeft; legLeft = item; break;
            case "Heart": tmpItem = heart; heart = item; break;
            case "Lungs": tmpItem = lungs; lungs = item; break;
            case "Stomach": tmpItem = stomach; stomach = item; break;
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        OnPartUpdated?.Invoke(this, EventArgs.Empty);
        return tmpItem;
    }
}
