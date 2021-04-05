using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotClickManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
            }
        }
    }

    public GameObject GetClickedSlotBackground()
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
