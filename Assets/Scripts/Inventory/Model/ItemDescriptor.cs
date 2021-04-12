using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

[CreateAssetMenu]
public class ItemDescriptor : ScriptableObject
{
    public ItemType itemType;
    public Sprite icon;

    public bool IsStackable()
    {
        switch(itemType)
        {
            case ItemType.Coin:
            case ItemType.HealthPotion:
                return true;
            default:
                return false;
        }
    }
}
