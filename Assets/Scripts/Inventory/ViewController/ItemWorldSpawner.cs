using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public ItemDescriptor itemDescr;
    public int amount;

    private void Start()
    {
        ItemWorld.SpawnItemWorld(transform.position, itemDescr, amount);
        Destroy(gameObject);
    }
}
