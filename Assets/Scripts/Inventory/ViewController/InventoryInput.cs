using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] private KeyCode toggleKey;
    [SerializeField] private GameObject fullInventory;

    private void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            fullInventory.SetActive(!fullInventory.activeSelf);
            Inventory.isInventoryOpened = fullInventory.activeSelf;
        }
    }

}
