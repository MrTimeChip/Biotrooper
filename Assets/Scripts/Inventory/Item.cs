using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Coin,
        Arm,
        Leg,
        HealPotion
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Coin: return ItemAssets.instance.coinSprite;
            case ItemType.Arm: return ItemAssets.instance.armSprite;
            case ItemType.Leg: return ItemAssets.instance.legSprite;
        }
    }

    public bool isStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Coin:
                return true;
            case ItemType.Arm:
            case ItemType.Leg:
                return false;
        }
    }
}
