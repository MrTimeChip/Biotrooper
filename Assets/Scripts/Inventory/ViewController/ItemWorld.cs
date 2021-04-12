using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, ItemDescriptor itemDescr, int amount)
    {
        var prefab = (GameObject)Resources.Load("pfItemWorld", typeof(GameObject));
        Transform transform = Instantiate(prefab.transform, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();

        var item = new Item();
        item.amount = amount;
        item.icon = itemDescr.icon;
        item.itemType = itemDescr.itemType;
        item.itemDescriptor = itemDescr;

        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.icon;
    }

    public Item GetItem()
    {
        return item;
    }    

}
