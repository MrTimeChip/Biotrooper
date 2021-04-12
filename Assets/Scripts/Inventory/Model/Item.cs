using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemType itemType;
    public int amount;
    public Sprite icon;
    public ItemDescriptor itemDescriptor;
    public int damage = 5;

    public bool IsStackable()
    {
        switch (itemType)
        {
            case ItemType.Coin:
            case ItemType.HealthPotion:
                return true;
            default:
                return false;
        }
    }
}
