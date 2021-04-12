using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryInputManager : MonoBehaviour
{
    [SerializeField] private KeyCode toggleKey;
    [SerializeField] private GameObject fullInventory;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            fullInventory.SetActive(!fullInventory.activeSelf);
            Inventory.isInventoryOpened = fullInventory.activeSelf;
        }

        if (Input.GetMouseButtonDown(0) && Inventory.isInventoryOpened)
        {
            GameObject partBackground = GetClickedPartSlotBackground();
            if (partBackground != null)
            {
                if (ItemPicker.instance.HaveItem())
                {
                    ItemPicker.instance.SetPart(partBackground.transform.parent.name);
                }
                else
                {
                    ItemPicker.instance.TakePart(partBackground.transform.parent.name);
                }
                return;
            }

            GameObject slotBackground = GetClickedSlotBackground();
            if (slotBackground != null)
            {
                if (ItemPicker.instance.HaveItem())
                {
                    ItemPicker.instance.SetItem(slotBackground.transform.parent.GetComponent<SlotScript>().slotNum);
                }
                else
                {

                    ItemPicker.instance.TakeItem(slotBackground.transform.parent.GetComponent<SlotScript>().slotNum);
                }
                return;
            }

            if (ItemPicker.instance.HaveItem())
            {
                ItemPicker.instance.DropItem();
            }
        }
    }

    private GameObject GetClickedPartSlotBackground()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.name == "PartBackground")
            {
                return results[i].gameObject;
            }
        }
        return null;
    }

    private GameObject GetClickedSlotBackground()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.name == "SlotBackground")
            {
                return results[i].gameObject;
            }
        }
        return null;
    }
}
