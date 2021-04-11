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
        Eyes,
        Body,
        Lungs,
        Heart,
        Stomach,
        HealthPotion
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
            case ItemType.Eyes: return ItemAssets.instance.eyesSprite;
            case ItemType.Body: return ItemAssets.instance.bodySprite;
            case ItemType.Lungs: return ItemAssets.instance.lungsSprite;
            case ItemType.Heart: return ItemAssets.instance.heartSprite;
            case ItemType.Stomach: return ItemAssets.instance.stomachSprite;
            case ItemType.HealthPotion: return ItemAssets.instance.healthPotionSprite;
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